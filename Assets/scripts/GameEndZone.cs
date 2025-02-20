using UnityEngine;

public class GameEndZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            int p1Score = ScoreManager.Instance.GetPlayer1Score();
            int p2Score = ScoreManager.Instance.GetPlayer2Score();

            if (p1Score > p2Score)
            {
                GameManager.Instance.EndGame("Player 1");
            }
            else if (p2Score > p1Score)
            {
                GameManager.Instance.EndGame("Player 2");
            }
            else
            {
                GameManager.Instance.EndGame("Tie");
            }
        }
    }
}
