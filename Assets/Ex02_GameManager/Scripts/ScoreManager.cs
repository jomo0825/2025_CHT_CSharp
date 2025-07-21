using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score;
    [SerializeField]
    private UnityEvent<int> evtUpdateScore;
    public UIScore uiScore;

    private void Start() {
        TriggerUpdateScore();
    }

    private void Update() {
        Test();
    }

    private void Test() {
        if (Input.GetKeyDown("a")) {
            AddScore(1);
        }
        if (Input.GetKeyDown("b")) {
            TriggerUpdateScore();
        }
    }

    public void AddScore(int points) {
        score += points;
    }

    public void TriggerUpdateScore() {
        evtUpdateScore?.Invoke(score);
    }

    public void Subscribe(UnityAction<int> action) {
        evtUpdateScore.AddListener(action);
    }

    public void Unsubscribe(UnityAction<int> action) {
        evtUpdateScore.RemoveListener(action);
    }
}
