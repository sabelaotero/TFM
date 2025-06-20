using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button reiniciar;
    [SerializeField] private TextMeshProUGUI puntuacion;

    private int finalScore;

    private void Start()
    {
        // Oculta el panel hasta el Game Over
        panel.SetActive(false);

        // Suscríbete a eventos
        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        GameManager.Instance.OnGameOver += ShowGameOver;

        reiniciar.onClick.AddListener(RestartScene);
    }

    private void OnDestroy()
    {
        // Limpia suscripciones
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= OnScoreChanged;
            GameManager.Instance.OnGameOver -= ShowGameOver;
        }
        reiniciar.onClick.RemoveListener(RestartScene);
    }

    private void OnScoreChanged(int score)
    {
        finalScore = score;
    }

    private void ShowGameOver()
    {
        puntuacion.text = $"Puntuación: {finalScore}";
        panel.SetActive(true);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}