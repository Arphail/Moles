using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _moveSpeedUpgrade;
    [SerializeField] private float _gravityValue;

    private Vector3 _playerVelocity;

    public bool IsMoving { get; private set; }

    private void Update()
    {
        if (_playerVelocity.y < 0)
            _playerVelocity.y = 0;

        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (move != Vector3.zero)
        {
            IsMoving = true;
            _controller.Move(move * _playerSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(move);
        }
        else
        {
            IsMoving = false;
        }

        _playerVelocity.y += -_gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void MoveSpeedUpgrade() => _playerSpeed += _moveSpeedUpgrade;
}
