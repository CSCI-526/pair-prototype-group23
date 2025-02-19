using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public float smoothSpeed = 5f;
    private float fixedX;

    void Start()
    {
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Assign both player transforms to the script.");
            enabled = false;
            return;
        }

        fixedX = transform.position.x; // Lock the camera's X position
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        float midY = (player1.position.y + player2.position.y) / 2f;
        Vector3 targetPosition = new Vector3(fixedX, midY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
