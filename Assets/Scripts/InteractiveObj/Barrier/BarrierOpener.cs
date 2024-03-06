using Base;
using Data;
using UnityEngine;

namespace InteractiveObj.Barrier
{
    public class BarrierOpener : MonoBehaviour
    {
        [SerializeField] private MoneyStash _base;
        [SerializeField] private BarrierUI _ui;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private DataSaver _saver;

        private Barrier _currentBarrier;

        public void OnBarrierOpenButtonClick()
        {
            if (_currentBarrier != null && _currentBarrier.Cost <= _base.Money)
            {
                _audioSource.Play();
                _currentBarrier.Open();
                _saver.SaveBarrier(_currentBarrier.SerialNumber);
                _base.SpendGold(_currentBarrier.Cost);
                _ui.HideButton();
            }
        }

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
    }
}
