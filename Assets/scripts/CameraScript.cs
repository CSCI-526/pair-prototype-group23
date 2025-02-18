using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player; // Assign the player GameObject in the Inspector
    private float fixedX;    // Stores the initial X position of the camera

    void Start()
    {
        if (player != null)
        {
            fixedX = transform.position.x; // Save the initial horizontal position
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update only the Y position, keeping X fixed
            transform.position = new Vector3(fixedX, player.position.y, transform.position.z);
        }
    }
}
