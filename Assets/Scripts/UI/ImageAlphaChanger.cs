using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageAlphaChanger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    private float _maxValue = 1;

    private void OnEnable()
    {
        _image.DOFade(_maxValue, _duration);
        _image.DOFade(0, _duration).SetDelay(_delay);
    }
}
