using System;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator), typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly string StartTrigger = "Jump";
    private readonly string DieTrigger = "Die";

    [SerializeField] private Menu _menu;
    [SerializeField] private PlayableDirector _playableDirector;

    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _menu.GameStarted += OnGameStarted;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _menu.GameStarted -= OnGameStarted;
        _player.Died -= OnDied;
    }

    private void OnGameStarted()
    {
        _animator.SetTrigger(StartTrigger);
        _playableDirector.Play();
    }

    private void OnDied()
    {
        _animator.SetTrigger(DieTrigger);
    }
}
