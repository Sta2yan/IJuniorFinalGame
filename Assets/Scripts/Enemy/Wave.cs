using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private WaveConfig[] _waveConfig;

    private WaveConfig _selectWaveConfig;
    private GameObject _spawnedObject;
    private Quaternion _targetRotation;
    private float _speed = 1f;
    private float _speedUp = 5f;
    private float _normalSpeed = 1f;
    private float _elapsedTime;

    private void OnEnable()
    {
        _selectWaveConfig = _waveConfig[Random.Range(0, _waveConfig.Length)];
        Spawn();
    }

    private void OnDisable()
    {
        if (_spawnedObject != null)
            Destroy(_spawnedObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        transform.Translate(Random.Range(_selectWaveConfig.MinSpeed, _selectWaveConfig.MaxSpeed) * _speed * Time.deltaTime * Vector3.up);

        if (_selectWaveConfig.IsRotate)
            _spawnedObject.transform.rotation = Quaternion.Lerp(_spawnedObject.transform.rotation,
                                                _targetRotation,
                                                Time.deltaTime);

        if (_elapsedTime >= _selectWaveConfig.MultiplySecondsSpeed)
        {
            _normalSpeed += _normalSpeed * _selectWaveConfig.MultiplySpeed;
            _speedUp += _speedUp * _selectWaveConfig.MultiplySpeed;

            _speed = _normalSpeed;

            _elapsedTime = 0;
        }
    }

    public void UpSpeed()
    {
        _speed = _speedUp;
    }

    public void DownSpeed()
    {
        _speed = _normalSpeed;
    }

    private void Spawn()
    {
        _spawnedObject = Instantiate(_selectWaveConfig.Template, transform);
        _spawnedObject.GetComponent<BoxCollider>().isTrigger = true;

        _targetRotation = Quaternion.Euler(Random.Range(_selectWaveConfig.MinAngleRotate, _selectWaveConfig.MaxAngleRotate),
                                           Random.Range(_selectWaveConfig.MinAngleRotate, _selectWaveConfig.MaxAngleRotate),
                                           Random.Range(_selectWaveConfig.MinAngleRotate, _selectWaveConfig.MaxAngleRotate));
    }
}