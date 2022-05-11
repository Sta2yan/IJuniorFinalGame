using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class CoinAnimation : MonoBehaviour
{
    private const string CollectedAnimation = "Collect";
    private const float StartAnimTime = 1.7f;
    private const float EndAnimPositionY = 1.25f;

    [SerializeField] private float _collectAnimPositionY = 3f;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.DOMoveY(EndAnimPositionY, StartAnimTime).SetEase(Ease.OutCirc);
    }

    public void Collect()
    {
        _animator.SetTrigger(CollectedAnimation);
        transform.DOMoveY(_collectAnimPositionY, StartAnimTime);
    }

    private void Delete()
    {
        gameObject.SetActive(false);
    }
}