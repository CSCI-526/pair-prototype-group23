using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text winnerText; 
    private void Start()
    {
        if (winnerText != null)
        {
            if (GameManager.finalWinnerName == "Tie")
            {
                winnerText.text = "It's a Tie!";
            }
            else
            {
                winnerText.text = GameManager.finalWinnerName + " Wins!";
            }
        }
    }

    public void OnPlayAgainClicked()
    {
        // Reload your main game scene
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
