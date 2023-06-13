using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAnimationHandler : MonoBehaviour
{
    [SerializeField] private Minion _minion;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_minion.IsStopped == false)
            _animator.SetBool("IsWalking", true);
        else
            _animator.SetBool("IsWalking", false);
    }
}
