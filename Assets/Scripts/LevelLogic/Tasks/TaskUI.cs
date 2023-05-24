using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    [SerializeField] private LevelTask _task;
    [SerializeField] private Slider _taskProgressionView;

    private void Start()
    {
        _taskProgressionView.maxValue = _task.TaskGoal;  
    }

    public void ShowTaskProgression(float currentTaskProgression)
    {
        _taskProgressionView.value = currentTaskProgression;
    }
}
