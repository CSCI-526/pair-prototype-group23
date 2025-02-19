using UnityEngine;

public class TileScript : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the colliding object is the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 playerPosition = collision.transform.position;
            Vector2 tilePosition = transform.position;

            // Calculate relative position
            Vector2 difference = tilePosition - playerPosition;

            // Check correct key press
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y)) // Player is left or right
            {
                if (difference.x > 0 && Input.GetKey(KeyCode.RightArrow)) // Player is left of the tile
                {
                    Destroy(gameObject);
                }
                else if (difference.x < 0 && Input.GetKey(KeyCode.LeftArrow)) // Player is right of the tile
                {
                    Destroy(gameObject);
                }
            }
            else // Player is above or below
            {
                if (difference.y > 0 && Input.GetKey(KeyCode.UpArrow)) // Player is below the tile
                {
                    Destroy(gameObject);
                }
                else if (difference.y < 0 && Input.GetKey(KeyCode.DownArrow)) // Player is above the tile
                {
                    Destroy(gameObject);
                }
            }
        }

        // Check if the colliding object is the Player
        if (collision.gameObject.CompareTag("Player2"))
        {
            Vector2 playerPosition = collision.transform.position;
            Vector2 tilePosition = transform.position;

            // Calculate relative position
            Vector2 difference = tilePosition - playerPosition;

            // Check correct key press
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y)) // Player is left or right
            {
                if (difference.x > 0 && Input.GetKey(KeyCode.D)) // Player is left of the tile
                {
                    Destroy(gameObject);
                }
                else if (difference.x < 0 && Input.GetKey(KeyCode.A)) // Player is right of the tile
                {
                    Destroy(gameObject);
                }
            }
            else // Player is above or below
            {
                if (difference.y > 0 && Input.GetKey(KeyCode.W)) // Player is below the tile
                {
                    Destroy(gameObject);
                }
                else if (difference.y < 0 && Input.GetKey(KeyCode.S)) // Player is above the tile
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
