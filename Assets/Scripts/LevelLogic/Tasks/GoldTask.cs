using UnityEngine;

public class GoldTask : LevelTask
{
    [SerializeField] private Base _base;

    private void Update()
    {
        if(_isFinished == false)
        {
            _ui.ShowTaskProgression(_base.Gold);
            CheckTaskProgression(_base.Gold);
        }
    }
}
