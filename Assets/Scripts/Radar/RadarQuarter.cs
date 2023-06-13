using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RadarQuarter : MonoBehaviour
{
    [SerializeField] private float _longDistance;
    [SerializeField] private float _midDistance;
    [SerializeField] private float _shortDistance;
    [SerializeField] private Image _longDistanceImage;
    [SerializeField] private Image _midDistanceImage;
    [SerializeField] private Image _shortDistanceImage;
    [SerializeField] private Color _basicColor;
    [SerializeField] private Color _activeColor;

    public void ShowDistance(float distance)
    {
        if (distance <= _shortDistance)
        {
            _longDistanceImage.color = _activeColor;
            _midDistanceImage.color = _activeColor;
            _shortDistanceImage.color = _activeColor;
        }

        if (distance > _shortDistance && distance < _midDistance)
        {
            _longDistanceImage.color = _activeColor;
            _midDistanceImage.color = _activeColor;
            _shortDistanceImage.color = _basicColor;
        }

        if (distance > _midDistance && distance < _longDistance)
        {
            _longDistanceImage.color = _activeColor;
            _midDistanceImage.color = _basicColor;
            _shortDistanceImage.color = _basicColor;
        }

        if(distance > _longDistance)
        {
            _longDistanceImage.color = _basicColor;
            _midDistanceImage.color = _basicColor;
            _shortDistanceImage.color = _basicColor;
        }
    }

    private void FixedUpdate()
    {
        _longDistanceImage.color = _basicColor;
        _midDistanceImage.color = _basicColor;
        _shortDistanceImage.color = _basicColor;
    }
}
