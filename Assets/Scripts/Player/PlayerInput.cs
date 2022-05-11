using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private const float DistanceFromCamera = 5f;

    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceFromCamera);

        _playerMover.TryMoveX(Camera.main.ScreenToWorldPoint(mousePosition).x);
        _playerMover.TryMoveZ(Camera.main.ScreenToWorldPoint(mousePosition).y);
    }
}