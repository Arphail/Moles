using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _playerSpeed;

    void Update()
    {
        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (move != Vector3.zero)
        {
            _controller.Move(move * _playerSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(move);
        }
    }
}
