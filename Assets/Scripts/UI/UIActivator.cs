using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pauseButton;

    private void OnEnable()
    {
        _gameStart.Started += OnGameStarted;
    }

    private void OnDisable()
    {
        _gameStart.Started -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        _scorePanel.SetActive(true);
        _pauseButton.SetActive(true);
    }
}
