using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    private const float Sleep = 4.3f;

    [SerializeField] private GameObject _template;
    [SerializeField] private float _maxSecondsBetweenSpawn;
    [SerializeField] private float _minSecondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _multiplySpawn;
    [SerializeField] private float _multiplySecondsSpawn;

    private float _secondsBetweenSpawn;
    private float _elapsedSpawnTime = 0f;
    private float _elapsedMultiplyTime = 0f;
    private Coroutine _coroutine;

    private void Start()
    {
        Initialize(_template);
        _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
    }

    private void Update()
    {
        _elapsedSpawnTime += Time.deltaTime;
        _elapsedMultiplyTime += Time.deltaTime;

        if (_elapsedSpawnTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject block))
            {
                Generate(block);

                _elapsedSpawnTime = 0;
                _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);
            }
        }

        if (_elapsedMultiplyTime >= _multiplySecondsSpawn)
        {
            _maxSecondsBetweenSpawn -= _maxSecondsBetweenSpawn * _multiplySpawn;
            _minSecondsBetweenSpawn -= _minSecondsBetweenSpawn * _multiplySpawn;

            _elapsedMultiplyTime = 0;
        }
    }

    public void TrySetSpeed()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(SetSpeed());
    }

    private IEnumerator SetSpeed()
    {
        float maxNormalSecondsBetweenSpawn = _maxSecondsBetweenSpawn;
        float minNormalSecondsBetweenSpawn = _minSecondsBetweenSpawn;

        _maxSecondsBetweenSpawn /= Sleep;
        _minSecondsBetweenSpawn /= Sleep;

        _secondsBetweenSpawn = Random.Range(_minSecondsBetweenSpawn, _maxSecondsBetweenSpawn);

        foreach (var item in Pool)
            item.GetComponent<Wave>().UpSpeed();

        yield return new WaitForSeconds(Sleep);

        foreach (var item in Pool)
            item.GetComponent<Wave>().DownSpeed();

        _maxSecondsBetweenSpawn = maxNormalSecondsBetweenSpawn;
        _minSecondsBetweenSpawn = minNormalSecondsBetweenSpawn;

        _coroutine = null;
    }

    private void Generate(GameObject block)
    {
        block.transform.position = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)].position;
        block.SetActive(true);

        DisableObjectAbroadScreen();
    }
}
