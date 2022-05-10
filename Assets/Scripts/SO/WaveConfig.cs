using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Config", menuName = "Scriptable Objects / New Wave Config", order = 51)]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private bool _isRotate;
    [SerializeField] private float _maxAngleRotate;
    [SerializeField] private float _minAngleRotate;
    [SerializeField] private float _multiplySpeed;
    [SerializeField] private float _multiplySecondsSpeed;

    public GameObject Template => _templates[Random.Range(0, _templates.Length)];
    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;
    public float MaxAngleRotate => _maxAngleRotate;
    public float MinAngleRotate => _minAngleRotate;
    public bool IsRotate => _isRotate;
    public float MultiplySpeed => _multiplySpeed;
    public float MultiplySecondsSpeed => _multiplySecondsSpeed;
}
