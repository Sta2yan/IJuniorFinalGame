using UnityEngine;
using DG.Tweening;

public class Clouds : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private float _endValueY;
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        _gameStart.Started += Move;
    }

    private void OnDisable()
    {
        _gameStart.Started -= Move;
    }

    private void Move()
    {
        transform.DOMoveY(_endValueY, _duration);
    }
}
