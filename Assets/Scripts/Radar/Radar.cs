using System.Collections.Generic;
using InteractiveObj.Goldmine;
using InteractiveObj.Treasure;
using UnityEngine;

namespace Radar
{
    public class Radar : MonoBehaviour
    {
        [SerializeField] private Transform _radar;
        [SerializeField] private RadarUI _radarUI;
        [SerializeField] private float _radarMaxDistance;

        private List<Goldmine> _goldmineList = new List<Goldmine>();
        private Treasure _currentTreasure;
        private bool _isLookingForTreasure;

        private void Update()
        {
            if (_goldmineList != null && _isLookingForTreasure == false)
            {
                foreach (var goldmine in _goldmineList)
                {
                    if (goldmine.IsActivated == false)
                    {
                        var distance = Vector3.Distance(_radar.position, goldmine.transform.position);

                        if (distance <= _radarMaxDistance)
                            _radarUI.ShowDistanceToTarget(distance, goldmine.transform);
                    }
                }
            }

            if (_currentTreasure != null && _isLookingForTreasure)
            {
                var distance = Vector3.Distance(_radar.position, _currentTreasure.transform.position);

                if (distance <= _radarMaxDistance)
                    _radarUI.ShowDistanceToTarget(distance, _currentTreasure.transform);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Goldmine goldmine) && _goldmineList.Contains(goldmine) == false)
                if (goldmine.IsActivated == false)
                    _goldmineList.Add(goldmine);

            if (other.TryGetComponent(out Treasure treasure))
                _currentTreasure = treasure;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Goldmine>(out Goldmine goldmine))
                if (_goldmineList.Contains(goldmine) == true)
                    _goldmineList.Remove(goldmine);

            if (other.TryGetComponent(out Treasure treasure))
                _currentTreasure = null;
        }

        public void SetTreasureMode() => _isLookingForTreasure = true;
        public void SetGoldmineMode() => _isLookingForTreasure = false;
    }
}
