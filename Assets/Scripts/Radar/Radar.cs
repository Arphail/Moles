using System.Collections.Generic;
using System.Linq;
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
                    var direction = target.transform.position - _radar.position;
                    float angle = Vector3.SignedAngle(direction, _radar.forward, Vector3.up);

                    if (angle > -45f && angle <= 45f)
                        _radarUI.DisplayTargetDirection(RadarUI.Up, distance, target.transform);

                    else if (angle > -135f && angle <= -45f)
                        _radarUI.DisplayTargetDirection(RadarUI.Right, distance, target.transform);

                    else if (angle > 45f && angle <= 135f)
                        _radarUI.DisplayTargetDirection(RadarUI.Left, distance, target.transform);

                    else
                        _radarUI.DisplayTargetDirection(RadarUI.Down, distance, target.transform);
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
