using UnityEngine;

public class TreasureTask : LevelTask
{
    [SerializeField] private TreasureSpawner _spawner;

    private void Update()
    {
        if(_isFinished == false)
        {
            _ui.ShowTaskProgression(_spawner.AccquiredTreasure);
            CheckTaskProgression(_spawner.AccquiredTreasure);
        }
    }
}
