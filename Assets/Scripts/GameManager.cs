using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManagerInstance;
    private static int _score;
    private static bool _isGamePaused;
    private static int _speedBall;
    private static int _shotsPerGame;
    private static float _speedRotation;
    
    internal static GameManager GameManagerInstance
    {
        get
        {
            if (_gameManagerInstance != null) return _gameManagerInstance;
            _gameManagerInstance = FindObjectOfType<GameManager>();
            if (_gameManagerInstance != null) return _gameManagerInstance;
            var gameManager = new GameObject(typeof(GameManager).Name);
            _gameManagerInstance = gameManager.AddComponent<GameManager>();
            DontDestroyOnLoad(gameManager);
            return _gameManagerInstance;
        }
    }
    
    internal static int Score
    {
        get => _score;
        set => _score = value;
    }
    internal static bool IsGamePaused
    {
        get => _isGamePaused;
        set => _isGamePaused = value;
    }
    
    internal static int SpeedBall
    {
        get => _speedBall;
        set => _speedBall = value;
    }
    
    internal static int ShotsPerGame
    {
        get => _shotsPerGame;
        set => _shotsPerGame = value;
    }
    
    internal static float SpeedRotation
    {
        get => _speedRotation;
        set => _speedRotation = value;
    }
    
    
    

    private void Awake()
    {
        if (_gameManagerInstance != null && _gameManagerInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

    internal void StartGame()
    {
        _score = 0;
        _isGamePaused = false;
    }

    internal void EndGame()
    {
        Debug.Log($"Game Over! Final Score:{_score} ");
    }

    internal void IncreaseScore(int amount)
    {
        _score += amount;
        Debug.Log($"Score increased! Current Score:{_score} ");
    }

    internal void PauseGame()
    {
        _isGamePaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
    }

    internal void ResumeGame()
    {
        _isGamePaused = false;
        Time.timeScale = 1f; 
        Debug.Log("Game Resumed");
    }
    

    internal void SaveGame()
    {
    }

    internal void LoadGame()
    {
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
}
