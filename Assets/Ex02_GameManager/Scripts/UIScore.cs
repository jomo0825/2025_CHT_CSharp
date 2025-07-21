using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public Image[] slots;
    public Sprite[] numbers;
    //public int testScore = 0;
    public ScoreManager scoreManager;

    private void OnEnable() {
        scoreManager.Subscribe(ShowScore);
    }

    private void OnDisable() {
        scoreManager.Unsubscribe(ShowScore);
    }

    private void Update() {
        //ShowScore(testScore);
    }

    public void ShowScore(int score) {
        //print(score);
        score = Mathf.Clamp(score, 0, 9999);
        int digit3 =  score / 1000;
        int digit2 = (score - digit3 * 1000) / 100;
        int digit1 = (score - digit3 * 1000 - digit2 * 100) / 10;
        int digit0 = (score - digit3 * 1000 - digit2 * 100 - digit1 * 10);
        slots[3].sprite = numbers[digit3];
        slots[2].sprite = numbers[digit2];
        slots[1].sprite = numbers[digit1];
        slots[0].sprite = numbers[digit0];
    }
}
