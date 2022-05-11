using System;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private const string LastScoreKey = "LastScore";
    private const string BestScoreKey = "BestScore";
    private const int ScoreUp = 5;

    [SerializeField] private Player _player;

    private int _score = 0;
    private int _lastScore = 0;
    private int _bestScore = 0;

    public event UnityAction ScoreChanged;

    public int CurrentScore => _score;
    public int LastScore => _lastScore;
    public int BestScore => _bestScore;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(LastScoreKey) == true)
            _lastScore = PlayerPrefs.GetInt(LastScoreKey);
        else
            PlayerPrefs.SetInt(LastScoreKey, 0);

        if (PlayerPrefs.HasKey(BestScoreKey) == true)
            _bestScore = PlayerPrefs.GetInt(BestScoreKey);
        else
            PlayerPrefs.SetInt(BestScoreKey, 0);
    }

    private void OnEnable()
    {
        _player.WaveCompleted += OnWaveCompleted;
        _player.CoinCollected += OnCoinCollected;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.WaveCompleted -= OnWaveCompleted;
        _player.CoinCollected -= OnCoinCollected;
        _player.Died -= OnDied;
    }

    private void OnWaveCompleted()
    {
        _score++;
        ScoreChanged?.Invoke();
    }

    private void OnCoinCollected()
    {
        _score += ScoreUp;
        ScoreChanged?.Invoke();
    }

    private void OnDied()
    {
        if (_score > _bestScore)
            PlayerPrefs.SetInt(BestScoreKey, _score);

        PlayerPrefs.SetInt(LastScoreKey, _score);
    }
}
