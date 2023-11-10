using UnityEngine;

public class MinionAnimationHandler : MonoBehaviour
{
    [SerializeField] private Minion _minion;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_minion.IsStopped == false)
            _animator.SetBool(Constants.IsWalkingTrigger, true);
        else
            _animator.SetBool(Constants.IsWalkingTrigger, false);
    }
}
