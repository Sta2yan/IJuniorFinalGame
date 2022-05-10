using UnityEngine;

public class GameStart : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private BoxCollider _playerBoxCollider;
    [SerializeField] private Outline _plyaerOutline;
    [SerializeField] private ParticleSystem _playerParticleSystem;

    [Header("UI")]
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pauseButton;

    [Header("Other")]
    [SerializeField] private GameObject _spawners;
    [SerializeField] private Clouds _clouds;
    [SerializeField] private Airplane _airplane;

    public void SetActivate()
    {
        _player.enabled = true;
        _playerInput.enabled = true;
        _playerMover.enabled = true;
        _playerBoxCollider.enabled = true;
        _plyaerOutline.enabled = true;
        _playerParticleSystem.Play();
        Camera.main.transform.position = new Vector3(0, 7, -1.5f);
        Camera.main.transform.rotation = Quaternion.Euler(43, 0, 0);
        _spawners.SetActive(true);
        _scorePanel.SetActive(true);
        _pauseButton.SetActive(true);
        _clouds.Move();
        _airplane.Fly();
    }
}
