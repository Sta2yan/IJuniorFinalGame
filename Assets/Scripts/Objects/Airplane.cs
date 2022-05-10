using UnityEngine;
using DG.Tweening;

public class Airplane : MonoBehaviour
{
    [SerializeField] private float _movePositionZ;
    [SerializeField] private float _timeMovePositionZ;
    [SerializeField] private float _movePositionY;
    [SerializeField] private float _timeMovePositionY;

    public void Fly()
    {
        transform.DOMoveZ(_movePositionZ, _timeMovePositionZ);
        transform.DOMoveY(_movePositionY, _timeMovePositionY);
    }
}
