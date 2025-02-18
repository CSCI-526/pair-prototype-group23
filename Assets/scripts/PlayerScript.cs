using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float jumpForce = 7f; // Adjusted for a 2-unit jump
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isGrounded; // Checks if player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        // Reset movement
        moveDirection = Vector2.zero;

        // Arrow key inputs for 2D movement
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    moveDirection += Vector2.up;
        //}
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector2.right;
        }

        // Normalize direction to avoid diagonal speed boost
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        // Jumping (Only if the player is grounded)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Jump upwards
            isGrounded = false; // Prevent double jumping
        }

    }

    void FixedUpdate()
    {
        // Move the player using Rigidbody2D physics
        //rb.linearVelocity = moveDirection * moveSpeed;
        // Apply horizontal movement
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is touching the ground
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
