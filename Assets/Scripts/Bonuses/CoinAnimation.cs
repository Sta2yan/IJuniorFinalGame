using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class CoinAnimation : MonoBehaviour
{
    private const string CollectedAnimation = "Collect";

    [SerializeField] private float _collectAnimPositionY = 3f;

    private Animator _animator;
    private float _startAnimTime = 1.7f;
    private float _endAnimPositionY = 1.25f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.DOMoveY(_endAnimPositionY, _startAnimTime).SetEase(Ease.OutCirc);
    }

    public void Collect()
    {
        _animator.SetTrigger(CollectedAnimation);
        transform.DOMoveY(_collectAnimPositionY, _startAnimTime);
    }

    private void Delete()
    {
        gameObject.SetActive(false);
    }
}