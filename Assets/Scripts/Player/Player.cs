using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    private float _sleep = 5f;
    private bool _isInvulnerability;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

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

        yield return new WaitForSeconds(_sleep);

        _isInvulnerability = false;
    }

    private void OnDied()
    {
        _rigidbody.isKinematic = false;
        _boxCollider.enabled = false;
        Died -= OnDied;
    }
}
