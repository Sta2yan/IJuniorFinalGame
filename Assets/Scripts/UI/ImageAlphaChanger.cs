using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageAlphaChanger : MonoBehaviour
{
    private const float MaxValue = 1;

    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        _image.DOFade(MaxValue, _duration);
        _image.DOFade(0, _duration).SetDelay(_delay);
    }
}
