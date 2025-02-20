using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isPaused = false;
    public float pauseTimer = 0f; // Remaining pause time

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator PauseForSeconds(float seconds)
    {
        isPaused = true;
        pauseTimer = seconds;
        while (pauseTimer > 0)
        {
            pauseTimer -= Time.deltaTime;
            yield return null;
        }
        isPaused = false;
        pauseTimer = 0f;
    }

    void Update()
    {
        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector2.down;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector2.left;
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector2.right;
        if (moveDirection.magnitude > 1)
            moveDirection.Normalize();

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;
    }
}
