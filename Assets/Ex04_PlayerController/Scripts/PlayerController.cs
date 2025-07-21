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
        // ����Dpad��J��X���ʦV�q
        movingVector = axisX * Vector3.right + axisY * Vector3.forward;
        // ��speed�v���PdeltaTime��X��V�������첾�A�|�[��Player��e��m
        transform.position = transform.position + speed * movingVector * Time.deltaTime;
        // �YDpad��J�����s(��YmovingVector�W�L�@�ӷ��p��)�A�h����i��V����Player
        if (movingVector.magnitude > 0.01f) {
            transform.forward = movingVector.normalized;
        }
    }
}
