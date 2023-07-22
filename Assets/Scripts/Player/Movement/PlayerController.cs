using UnityEngine;
using Agava.YandexGames;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _moveSpeedUpgrade;
    [SerializeField] private float _gravityValue;

    private Vector3 _playerVelocity;
    private Vector3 _mobileInput;
    private Vector3 _desktopInput;

    public bool IsMoving { get; private set; }

    private void Update()
    {
        _mobileInput = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        _desktopInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (_playerVelocity.y < 0)
            _playerVelocity.y = 0;

        if (Device.Type.ToString() == "Desktop")
            Move(_desktopInput);
        else
            Move(_mobileInput);

        _playerVelocity.y += -_gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void MoveSpeedUpgrade() => _playerSpeed += _moveSpeedUpgrade;

    private void Move(Vector3 move)
    {
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
    }
}
