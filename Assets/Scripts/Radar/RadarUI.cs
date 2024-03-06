using UnityEngine;

namespace Radar
{
    public class RadarUI : MonoBehaviour
    {
        [SerializeField] private RadarQuarter _quarterUp;

        public void ShowDistanceToTarget(float distance, Transform target)
        {
            if (target.gameObject.activeSelf == true)
                _quarterUp.ShowDistance(distance, target);
        }
    }
}
