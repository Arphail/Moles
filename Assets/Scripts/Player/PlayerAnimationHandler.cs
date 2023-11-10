using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _controller;

    private void Update()
    {
        if (_controller.IsMoving)
            _animator.SetBool(Constants.IsWalkingTrigger, true);
        else
            _animator.SetBool(Constants.IsWalkingTrigger, false);
    }
}
