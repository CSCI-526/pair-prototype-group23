using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void OnPlayGameClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
