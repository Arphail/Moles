using UnityEngine;

public class RadarUI : MonoBehaviour
{
    [SerializeField] private RadarQuarter _quarterUp;

    public void DisplayTargetDirection(float distance, Transform target)
    {
        if (target.gameObject.activeSelf == true)
            _quarterUp.ShowDistance(distance, target);
    }
}
