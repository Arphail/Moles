using UnityEngine;

namespace InteractiveObj.Goldmine
{
    public class GoldmineModelChanger : MonoBehaviour
    {
        [SerializeField] private GameObject[] _models;
        [SerializeField] private ParticleSystem[] _effects;

        private GameObject _currentModel;
        private int _currentModelIndex;

        private void Awake()
        {
            _currentModel = _models[_currentModelIndex];
        }

        public void ChangeToNextModel()
        {
            if (_currentModelIndex == _models.Length - 1)
                return;

            _currentModel.SetActive(false);
            
            _currentModelIndex++;
            _currentModel = _models[_currentModelIndex];

            foreach (var effect in _effects)
                effect.Play();

            _currentModel.SetActive(true);
        }
    }
}
