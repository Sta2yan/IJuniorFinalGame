using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private const float Sleep = 5f;

    [SerializeField] private Vector3 _startPosition;

    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private bool _isInvulnerability;

    public UnityAction WaveCompleted;
    public UnityAction CoinCollected;
    public UnityAction Died;
    public UnityAction RingCollected;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        transform.position = _startPosition;
        Died += OnDied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BonusRing bonusRing))
        {
            SetInvulnerability();
            RingCollected?.Invoke();
        }
        else if (other.gameObject.TryGetComponent(out Wave wave))
        {
            WaveCompleted?.Invoke();
        }
        else if (other.gameObject.TryGetComponent(out CoinAnimation coin))
        {
            CoinCollected?.Invoke();
            coin.Collect();
        }
        else
        {
            if (_isInvulnerability == false)
            {
                Died?.Invoke();
            }
        }
    }

    private void SetInvulnerability()
    {
        StartCoroutine(Invulnerability());
    }

    private IEnumerator Invulnerability()
    {
        _isInvulnerability = true;

        yield return new WaitForSeconds(Sleep);

        _isInvulnerability = false;
    }

    private void OnDied()
    {
        _rigidbody.isKinematic = false;
        _boxCollider.enabled = false;
        Died -= OnDied;
    }
}
