// UIDice.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDice : MonoBehaviour
{
    public RawImage imgDice;
    public Button btnRoll;
    public Texture[] texDice;
    private bool isRolling = false;
    private Coroutine runningCoroutine = null;
    private int target = 0;
    public int shuffleInterval = 2;
    public float shuffleScale = 1.2f;
    private int shuffleTarget = 0;
    private int shuffleCount = 0;
    public ScoreManager scoreManager;
    public InputManager inputManager;
    public Animator anim;
    private string state = "off";

    private void Update() {
        if (isRolling) {
            if (shuffleCount >= shuffleTarget) {
                shuffleCount = 0;
                shuffleTarget = (int)Mathf.Ceil(shuffleTarget
                    * shuffleScale);
                target = Random.Range(0, texDice.Length);
                SwitchDiceTexture(target);
            }
            shuffleCount++;
        }
    }

    private void OnEnable() {
        InputManager.Instance.SubscribeMenuToggle(MenuToggle);   
    }

    private void OnDisable() {
        InputManager.Instance.UnsubscribeMenuToggle(MenuToggle);
    }

    public void MenuToggle() {
        if (state == "off") {
            state = "on";
            anim.Play("SlideIn");
        }
        else {
            state = "off";
            anim.Play("SlideOut");
        }
    }

    public void StartRolling() {
        if (runningCoroutine == null) {
            runningCoroutine = StartCoroutine(RollDice());
        }
    }

    private void SwitchDiceTexture(int target) {
        imgDice.texture = texDice[target];
    }

    private IEnumerator RollDice() {
        shuffleCount = 0;
        shuffleTarget = shuffleInterval;
        isRolling = true;
        yield return new WaitForSeconds(1);
        isRolling = false;
        runningCoroutine = null;
        scoreManager.AddScore(target + 1);
        scoreManager.TriggerUpdateScore();
    }
}
