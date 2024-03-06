using UnityEngine;

public class MinionAnimationHandler : MonoBehaviour
{
    [SerializeField] private Minion _minion;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        _animator.SetBool(Constants.IsWalkingTrigger, _minion.IsStopped == false);
    }
}
