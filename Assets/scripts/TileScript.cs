using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isRedTile = false;
    public bool isBlackTile = false;
    public bool isPausedTile = false; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isPausedTile)
            {
                GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
                if (player2 != null)
                {
                    PlayerScript2 ps2 = player2.GetComponent<PlayerScript2>();
                    if (ps2 != null && !ps2.isPaused)
                    {
                        ps2.StartCoroutine(ps2.PauseForSeconds(5f));
                    }
                }
                Destroy(gameObject);
                return;
            }

            if (isBlackTile)
            {
                GameManager.Instance.EndGame("Player 2");
                Destroy(gameObject);
                return;
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            if (isPausedTile)
            {
                GameObject player1 = GameObject.FindGameObjectWithTag("Player");
                if (player1 != null)
                {
                    PlayerScript ps1 = player1.GetComponent<PlayerScript>();
                    if (ps1 != null && !ps1.isPaused)
                    {
                        ps1.StartCoroutine(ps1.PauseForSeconds(5f));
                    }
                }
                Destroy(gameObject);
                return;
            }

            if (isBlackTile)
            {
                GameManager.Instance.EndGame("Player 1");
                Destroy(gameObject);
                return;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isRedTile && CheckDirectionalKeyForPlayer1(collision.transform))
            {
                Destroy(gameObject);
                ScoreManager.Instance.AddScorePlayer1(1);
                return;
            }
            if (!isPausedTile && !isBlackTile && !isRedTile && CheckDirectionalKeyForPlayer1(collision.transform))
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            if (isRedTile && CheckDirectionalKeyForPlayer2(collision.transform))
            {
                Destroy(gameObject);
                ScoreManager.Instance.AddScorePlayer2(1);
                return;
            }
            if (!isPausedTile && !isBlackTile && !isRedTile && CheckDirectionalKeyForPlayer2(collision.transform))
            {
                Destroy(gameObject);
            }
        }
    }

    private bool CheckDirectionalKeyForPlayer1(Transform playerTransform)
    {
        Vector2 diff = (Vector2)transform.position - (Vector2)playerTransform.position;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
 
            if (diff.x > 0)
                return Input.GetKey(KeyCode.D);
            else
                return Input.GetKey(KeyCode.A);
        }
        else
        {
            if (diff.y > 0)
                return Input.GetKey(KeyCode.W);
            else
                return Input.GetKey(KeyCode.S);
        }
    }

    
    private bool CheckDirectionalKeyForPlayer2(Transform playerTransform)
    {
        Vector2 diff = (Vector2)transform.position - (Vector2)playerTransform.position;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            if (diff.x > 0)
                return Input.GetKey(KeyCode.RightArrow);
            else
                return Input.GetKey(KeyCode.LeftArrow);
        }
        else
        {
            if (diff.y > 0)
                return Input.GetKey(KeyCode.UpArrow);
            else
                return Input.GetKey(KeyCode.DownArrow);
        }
    }
}
