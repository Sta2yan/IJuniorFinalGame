using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private Outline _outline;
    [SerializeField] private ParticleSystem _particleSystem;

    private Player _player;
    private PlayerInput _input;
    private PlayerMover _mover;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _gameStart.Started += OnGameStarted;
    }

    private void OnDisable()
    {
        _gameStart.Started -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        _player.enabled = true;
        _input.enabled = true;
        _mover.enabled = true;
        _boxCollider.enabled = true;
        _outline.enabled = true;
        _particleSystem.Play();
    }
}
