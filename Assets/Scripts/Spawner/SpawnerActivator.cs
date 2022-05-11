using UnityEngine;
using System.Collections.Generic;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] private GameStart _gameStart;
    [SerializeField] private List<Spawner> _spawners;

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
        foreach (var spawner in _spawners)
            spawner.gameObject.SetActive(true);
    }
}
