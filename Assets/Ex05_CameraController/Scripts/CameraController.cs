using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 此範例我們不使用手動配置playerController
    public PlayerController playerController;
    private Vector3 startingOffset;
    private Vector3 smoothVelocity = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 而是改採FindFirstObjectByType()，尋找關卡內對應組件
        playerController = FindFirstObjectByType<PlayerController>();    
        startingOffset = transform.position - playerController.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = playerController.transform.position + startingOffset
            + playerController.movingVector * 2f              // 動態延展距離
            + playerController.transform.forward * 2.5f       // 靜態延展距離
            - Vector3.forward * Mathf.Pow(playerController.movingVector.magnitude, 2f) * 2f;  // 深度延展距離
        
        // 硬轉換
        //transform.position = targetPosition;
        
        // 軟轉換 - Lerp
        //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.03f);
        
        // 軟轉換 - SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref smoothVelocity, 0.5f);
    }
}
