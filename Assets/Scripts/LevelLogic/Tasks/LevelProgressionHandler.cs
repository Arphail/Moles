using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressionHandler : MonoBehaviour
{
    [SerializeField] private LevelTask[] _levelTasks;
    [SerializeField] private GameObject _levelFinishScreen;

    private float _tasksToFinish;
    private float _finishedTasks;

    private void Start()
    {
        _tasksToFinish = _levelTasks.Length;
        _finishedTasks = 0;
    }

    private void OnEnable()
    {
        foreach (var task in _levelTasks)
            task.TaskFinished += OnTaskFinished;
    }

    private void OnDisable()
    {
        foreach (var task in _levelTasks)
            task.TaskFinished -= OnTaskFinished;
    }

    private void Update()
    {
        if (_finishedTasks == _tasksToFinish)
            _levelFinishScreen.gameObject.SetActive(true);
    }

    private void OnTaskFinished()
    {
        _finishedTasks++;
    }
}
