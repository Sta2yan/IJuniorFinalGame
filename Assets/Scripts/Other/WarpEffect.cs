using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WarpEffect : MonoBehaviour
{
    [SerializeField] private Player _player;

    private ParticleSystem _system;

    private void Awake()
    {
        _system = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        _player.RingCollected += OnRingCollected;
    }

    private void OnDisable()
    {
        _player.RingCollected -= OnRingCollected;
    }
     
    private void OnRingCollected()
    {
        _system.Play();
    }
}
