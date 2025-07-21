using UnityEngine;

public class CameraController : MonoBehaviour
{
    // ���d�ҧڭ̤��ϥΤ�ʰt�mplayerController
    public PlayerController playerController;
    private Vector3 startingOffset;
    private Vector3 smoothVelocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �ӬO���FindFirstObjectByType()�A�M�����d�������ե�
        playerController = FindFirstObjectByType<PlayerController>();    
        startingOffset = transform.position - playerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = playerController.transform.position + startingOffset
            + playerController.movingVector * 2f              // �ʺA���i�Z��
            + playerController.transform.forward * 2.5f       // �R�A���i�Z��
            - Vector3.forward * Mathf.Pow(playerController.movingVector.magnitude, 2f) * 2f;  // �`�ש��i�Z��
        
        // �w�ഫ
        //transform.position = targetPosition;
        
        // �n�ഫ - Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.03f);
        
        // �n�ഫ - SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, 0.5f);
    }
}
