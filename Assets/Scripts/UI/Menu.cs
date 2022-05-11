using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    public event UnityAction GameStarted;

    private void Start()
    {
        StartGame();
    }

    public void Play()
    {
        _startPanel.SetActive(false);
        GameStarted?.Invoke();
    }

    private void StartGame()
    {
        _startPanel.SetActive(true);
    }
}