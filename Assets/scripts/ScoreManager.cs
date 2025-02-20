using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
    public TMP_Text player1PauseTimerText;
    public TMP_Text player2PauseTimerText;

    public PlayerScript player1Controller;
    public PlayerScript2 player2Controller;

    private int player1Score = 0;
    private int player2Score = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (player1ScoreText != null)
            player1ScoreText.color = new Color32(0x3E, 0xFF, 0x0B, 0xFF);
        if (player2ScoreText != null)
            player2ScoreText.color = new Color32(0x21, 0xDA, 0xD0, 0xFF);
    }

    public int GetPlayer1Score() { return player1Score; }
    public int GetPlayer2Score() { return player2Score; }

    public void AddScorePlayer1(int amount)
    {
        player1Score += amount;
        UpdateUI();
    }

    public void AddScorePlayer2(int amount)
    {
        player2Score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (player1ScoreText != null)
            player1ScoreText.text = "Player 1: " + player1Score;
        if (player2ScoreText != null)
            player2ScoreText.text = "Player 2: " + player2Score;

        if (player1Controller != null && player1Controller.isPaused && player1PauseTimerText != null)
            player1PauseTimerText.text = "Paused: " + Mathf.Ceil(player1Controller.pauseTimer) + "s";
        else if (player1PauseTimerText != null)
            player1PauseTimerText.text = "";

        if (player2Controller != null && player2Controller.isPaused && player2PauseTimerText != null)
            player2PauseTimerText.text = "Paused: " + Mathf.Ceil(player2Controller.pauseTimer) + "s";
        else if (player2PauseTimerText != null)
            player2PauseTimerText.text = "";
    }

    void Update()
    {
        UpdateUI();
    }
}
