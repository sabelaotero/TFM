using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<int> OnScoreChanged;
    public event Action<float> OnTimerChanged;
    public event Action OnGameOver;

    public bool IsGameOver { get; private set; }

    [SerializeField] private float gameDuration = 120f;
    private int score;
    private float timer;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        score = 0;
        timer = gameDuration;
        OnScoreChanged?.Invoke(score);
        OnTimerChanged?.Invoke(timer);
    }

    private void Update()
    {
        if (IsGameOver) 
            return;

        timer -= Time.deltaTime;
        OnTimerChanged?.Invoke(timer);

        if (timer <= 0f)
        {
            timer = 0f;
            EndGame();
        }
    }

    public void AddScore(int amount)
    {
        if (IsGameOver) return;
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    private void EndGame()
    {
        IsGameOver = true;
        OnGameOver?.Invoke();
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}