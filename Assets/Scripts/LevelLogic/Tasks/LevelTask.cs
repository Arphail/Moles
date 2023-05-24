using UnityEngine;
using UnityEngine.Events;

public abstract class LevelTask : MonoBehaviour
{
    [SerializeField] protected float _taskGoal;
    [SerializeField] protected TaskUI _ui;

    public event UnityAction TaskFinished;

    protected bool _isFinished;

    public float TaskGoal => _taskGoal;

    public virtual void CheckTaskProgression(float taskValue)
    {
        if (taskValue >= _taskGoal)
        {
            TaskFinished?.Invoke();
            _isFinished = true;
        }
    }
}
    