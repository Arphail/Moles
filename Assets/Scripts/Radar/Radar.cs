using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private Transform _radar;
    [SerializeField] private RadarUI _radarUI;
    [SerializeField] private float _radarMaxDistance;

    private List <Goldmine> _targets = new List<Goldmine>();

    void Update()
    {
        if (_targets != null)
        {
            foreach (var target in _targets)
            {
                if (target.IsActivated == false)
                {
                    var distance = Vector3.Distance(_radar.position, target.transform.position);

                    if (distance <= _radarMaxDistance)
                        _radarUI.DisplayTargetDirection(distance, target.transform);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Goldmine goldmine) && _targets.Contains(goldmine) == false)
        {
            if (goldmine.IsActivated == false)
                _targets.Add(goldmine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<Goldmine>(out Goldmine goldmine))
        {
            if (_targets.Contains(goldmine) == true)
                _targets.Remove(goldmine);
        }
    }
}
