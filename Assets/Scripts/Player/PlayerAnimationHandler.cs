using Data;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerMovement _controller;

        private void Update()
        {
            _animator.SetBool(Constants.IsWalkingTrigger, _controller.IsMoving);
        }
    }
}
