using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnTimerChanged += UpdateTimer;
        GameManager.Instance.OnGameOver += ShowGameOver;

        restartButton.onClick.AddListener(GameManager.Instance.RestartGame);
        gameOverPanel.SetActive(false);
    }

    private void UpdateScore(int score) => scoreText.text = $"Puntuación: {score}";
    private void UpdateTimer(float time) => timerText.text = $"Tiempo restante: {Mathf.CeilToInt(time)}";
    private void ShowGameOver() => gameOverPanel.SetActive(true);
}