using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null) {
                // 若場景中不存在，就動態新增一個 GameObject
                var singletonObject = new GameObject(typeof(T).ToString());
                instance = singletonObject.AddComponent<T>();
                // 避免場景切換時被刪除
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    private void Awake() {
        // 若本組件Awake時發現尚未有人註冊成為instance
        if (instance == null) {
            // 則將自己註冊成為instance
            instance = this as T;
            // 向引擎標註本GameObject切換場景時不要刪除
            DontDestroyOnLoad(gameObject);
        }
        // 若本組件Awake時發現已經有人註冊成為instance
        else if (instance != this) {
            // 則刪除自己
            Destroy(gameObject);
        }
    }
}
