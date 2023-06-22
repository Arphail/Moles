using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelFinishingZone : MonoBehaviour
{
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Base _base;
    [SerializeField] private int _cost;
    [SerializeField] private LevelFinishUi _ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _ui.ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _ui.HideUI();
        }
    }

    public void TryLoadNextLevel()
    {
        if (_base.Gold >= _cost)
            _levelLoader.LoadNextLevel();
        else
            print("Недостаточно золота");
    }
}
