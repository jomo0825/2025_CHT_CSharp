using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public InputManager inputManager;
    public float speed = 3.0f;
    public Vector3 movingVector;

    private void OnEnable() {
        InputManager.Instance.SubscribeDpad(Move);
    }

    private void OnDisable() {
        InputManager.Instance.UnsubscribeDpad(Move);
    }

    public void Move(float axisX, float axisY) {
        // 按照Dpad輸入算出移動向量
        movingVector = axisX * Vector3.right + axisY * Vector3.forward;
        // 按speed權重與deltaTime算出兩幀之間的位移，疊加至Player當前位置
        transform.position = transform.position + speed * movingVector * Time.deltaTime;
        // 若Dpad輸入不為零(亦即movingVector超過一個極小值)，則按行進方向旋轉Player
        if (movingVector.magnitude > 0.01f) {
            transform.forward = movingVector.normalized;
        }
    }
}
