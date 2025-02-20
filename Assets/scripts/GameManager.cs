using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static string finalWinnerName;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EndGame(string winner)
    {
        finalWinnerName = winner;

        SceneManager.LoadScene("EndGame");
    }


}
