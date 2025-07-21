using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null) {
                // �Y���������s�b�A�N�ʺA�s�W�@�� GameObject
                var singletonObject = new GameObject(typeof(T).ToString());
                instance = singletonObject.AddComponent<T>();
                // �קK���������ɳQ�R��
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    private void Awake() {
        // �Y���ե�Awake�ɵo�{�|�����H���U����instance
        if (instance == null) {
            // �h�N�ۤv���U����instance
            instance = this as T;
            // �V�����е���GameObject���������ɤ��n�R��
            DontDestroyOnLoad(gameObject);
        }
        // �Y���ե�Awake�ɵo�{�w�g���H���U����instance
        else if (instance != this) {
            // �h�R���ۤv
            Destroy(gameObject);
        }
    }
}
