using UnityEngine;
using DG.Tweening;

public class Clouds : MonoBehaviour
{
    [SerializeField] private float _endValueY;
    [SerializeField] private float _duration;

    public void Move()
    {
        transform.DOMoveY(_endValueY, _duration);
    }
}
