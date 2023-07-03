using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierOpener : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private BarrierUI _ui;
    [SerializeField] private SoundHandler _soundHandler;

    private Barrier _currentBarrier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Barrier>(out Barrier barrier))
        {
            _currentBarrier = barrier;
            _ui.ShowButton(_currentBarrier.Cost.ToString());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Barrier>(out Barrier barrier))
        {
            _ui.HideButton();
            _currentBarrier = null;
        }
    }

    public void TryOpenBarrier()
    {
        if( _currentBarrier != null && _currentBarrier.Cost <= _base.Gold)
        {
            _soundHandler.PlaySound();
            _currentBarrier.Open();
            _base.SpendGold(_currentBarrier.Cost);
            _ui.HideButton();
        }
        else
        {
            print("Недостаточно золота.");
        }
    }
}
