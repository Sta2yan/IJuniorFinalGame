using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;

    private Vector3 _targetPosition;
    private float _distance;
    private float _distanceMultiplier = 2f;
    private float _transformPositionX;
    private float _transformPositionZ;
    private float _multiplyAngleRotation = 1700f;
    private float _multiplyTimeRotation = 2;
    private bool _isActive = true;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _targetPosition = Vector3.zero;
        transform.rotation = Quaternion.identity;
        _isActive = true;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void Update()
    {
        if (_isActive == true)
        {
            _distance = Vector3.Distance(transform.position, _targetPosition);

            _transformPositionX = transform.position.x;
            _transformPositionZ = transform.position.z;

            Move(_distance);
            HorizontalRotate(_transformPositionX);
            VerticalRotate(_transformPositionZ);
        }
    }

    public void TryMoveX(float position)
    {
        if (position > _minPositionX && position < _maxPositionX)
            SetTargetPositionX(position);
    }

    public void TryMoveZ(float position)
    {
        if (position > _minPositionZ && position < _maxPositionZ)
            SetTargetPositionZ(position);
    }

    private void Move(float distance)
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * distance / _distanceMultiplier * Time.deltaTime);
    }

    private void HorizontalRotate(float positionX)
    {
        if (positionX < transform.position.x)
            transform.localRotation = Quaternion.Lerp(transform.localRotation,
                                                      Quaternion.Euler(transform.rotation.x,
                                                                       transform.rotation.y,
                                                                       transform.rotation.z + ((positionX - transform.position.x) * _multiplyAngleRotation)),
                                                      Time.deltaTime * _multiplyTimeRotation);
        else if (positionX > transform.position.x)
            transform.localRotation = Quaternion.Lerp(transform.localRotation,
                                                      Quaternion.Euler(transform.rotation.x,
                                                                       transform.rotation.y,
                                                                       transform.rotation.z - ((transform.position.x - positionX) * _multiplyAngleRotation)),
                                                      Time.deltaTime * _multiplyTimeRotation);
    }

    private void VerticalRotate(float positionZ)
    {
        if (positionZ < transform.position.z)
            transform.localRotation = Quaternion.Lerp(transform.localRotation,
                                                      Quaternion.Euler(transform.rotation.x + ((transform.position.z - positionZ) * _multiplyAngleRotation),
                                                                       transform.rotation.y,
                                                                       transform.rotation.z),
                                                      Time.deltaTime * _multiplyTimeRotation);
        else if (positionZ > transform.position.z)
            transform.localRotation = Quaternion.Lerp(transform.localRotation,
                                                      Quaternion.Euler(transform.rotation.x - ((positionZ - transform.position.z) * _multiplyAngleRotation),
                                                                       transform.rotation.y,
                                                                       transform.rotation.z),
                                                      Time.deltaTime * _multiplyTimeRotation);
    }

    private void SetTargetPositionX(float position)
    {
        _targetPosition = new Vector3(position, _targetPosition.y, _targetPosition.z);
    }

    private void SetTargetPositionZ(float position)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y, position - 1);
    }

    private void OnDied()
    {
        _isActive = false;
    }
}