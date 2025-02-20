using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    
    [Header("Camera Movement Settings")]
    public float smoothSpeed = 5f;    
    private float fixedX;            

    [Header("Camera Zoom Settings")]
    public float zoomSpeed = 2f;           
    public float margin = 2f;              
    public float minOrthographicSize = 5f; 
    public float maxOrthographicSize = 10f;
    
    private Camera cam;

    void Start()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Assign both player transforms to the script.");
            enabled = false;
            return;
        }

        cam = Camera.main;
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        float midY = (player1.position.y + player2.position.y) / 2f;
        Vector3 targetPosition = new Vector3(fixedX, midY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        float distanceY = Mathf.Abs(player1.position.y - player2.position.y);
        float requiredSize = distanceY / 2f + margin;

        float desiredSize = Mathf.Clamp(requiredSize, minOrthographicSize, maxOrthographicSize);

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, desiredSize, zoomSpeed * Time.deltaTime);
    }
}
