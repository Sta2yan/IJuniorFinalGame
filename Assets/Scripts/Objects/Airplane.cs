using UnityEngine;
using DG.Tweening;

public class Airplane : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private float _movePositionZ;
    [SerializeField] private float _timeMovePositionZ;
    [SerializeField] private float _movePositionY;
    [SerializeField] private float _timeMovePositionY;

    private void OnEnable()
    {
        _gameStart.Started += Fly;
    }

    private void OnDisable()
    {
        _gameStart.Started -= Fly;
    }

    private void Fly()
    {
        transform.DOMoveZ(_movePositionZ, _timeMovePositionZ);
        transform.DOMoveY(_movePositionY, _timeMovePositionY);
    }
}
