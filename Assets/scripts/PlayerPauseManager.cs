using UnityEngine;

public class PlayerPauseManager : MonoBehaviour
{
    public static PlayerPauseManager Instance;

    [Tooltip("Duration to pause a player (in seconds)")]
    public float pauseDuration = 5f;

    public bool isPlayer1Paused = false;
    public bool isPlayer2Paused = false;

    public float player1PauseTimer = 0f;
    public float player2PauseTimer = 0f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isPlayer1Paused)
        {
            player1PauseTimer -= Time.deltaTime;
            if (player1PauseTimer <= 0f)
            {
                isPlayer1Paused = false;
                player1PauseTimer = 0f;
            }
        }
        if (isPlayer2Paused)
        {
            player2PauseTimer -= Time.deltaTime;
            if (player2PauseTimer <= 0f)
            {
                isPlayer2Paused = false;
                player2PauseTimer = 0f;
            }
        }
    }

    public void PausePlayer1()
    {
        isPlayer1Paused = true;
        player1PauseTimer = pauseDuration;
    }

    public void PausePlayer2()
    {
        isPlayer2Paused = true;
        player2PauseTimer = pauseDuration;
    }
}
