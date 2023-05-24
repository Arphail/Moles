using UnityEngine;

public class MinionTask : LevelTask
{
    [SerializeField] private MinionSpawner _spawner;

    private void Update()
    {
        if(_isFinished == false)
        {
            _ui.ShowTaskProgression(_spawner.SpawnedMinions);
            CheckTaskProgression(_spawner.SpawnedMinions);
        }
    }
}
