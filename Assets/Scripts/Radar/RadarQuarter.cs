using UnityEngine;
using UnityEngine.UI;

public class RadarQuarter : MonoBehaviour
{
    [SerializeField] private float _longDistance;
    [SerializeField] private float _midDistance;
    [SerializeField] private float _shortDistance;
    [SerializeField] private RawImage _longDistanceImage;
    [SerializeField] private RawImage _midDistanceImage;
    [SerializeField] private RawImage _shortDistanceImage;
    [SerializeField] private Color _basicColor;
    [SerializeField] private Color _goldmineVisualColor;
    [SerializeField] private Color _treasureVisualColor;

    private Color _currentColor;

    public void ShowDistance(float distance, Transform target)
    {
        if(target.gameObject.TryGetComponent<Goldmine>(out Goldmine goldmine))
            _currentColor = _goldmineVisualColor;

        if(target.gameObject.TryGetComponent<Treasure>(out Treasure treasure))
            _currentColor = _treasureVisualColor;

        if (distance <= _shortDistance)
        {
            _longDistanceImage.color = _currentColor;
            _midDistanceImage.color = _currentColor;
            _shortDistanceImage.color = _currentColor;
        }

        if (distance > _shortDistance && distance < _midDistance)
        {
            _longDistanceImage.color = _currentColor;
            _midDistanceImage.color = _currentColor;
            _shortDistanceImage.color = _basicColor;
        }

        if (distance > _midDistance && distance < _longDistance)
        {
            _longDistanceImage.color = _currentColor;
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
