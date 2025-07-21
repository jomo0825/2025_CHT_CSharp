using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class GameManager : Singleton<GameManager>
{
    public string savefileName = "save.txt";

    private void Start() {
    }

    private void OnEnable() {
        InputManager.Instance.SubscribeSave(Save);
    }

    private void OnDisable() {
        InputManager.Instance.UnsubscribeSave(Save);
    }

    public async void Save() {
        print("saving..");
        await WriteFile(ScoreManager.Instance.score.ToString());
    }

    public async Task WriteFile(string content) {
        string path = Path.Combine(Application.streamingAssetsPath, savefileName);
        try {
            await File.WriteAllTextAsync(path, content);
            Debug.Log("存檔成功");
        }
        catch (System.Exception) {
            Debug.LogError("存檔失敗!");
        }
    }
}
