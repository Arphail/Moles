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
    [SerializeField] private Color _goldmineColor;
    [SerializeField] private Color _treasureColor;

    private Color _currentActiveColor;

    public void ShowDistance(float distance, Transform target)
    {
        if (target.TryGetComponent(out Goldmine goldmine))
            _currentActiveColor = _goldmineColor;
        else if (target.TryGetComponent(out Treasure treasure))
            _currentActiveColor = _treasureColor;

        if (distance <= _shortDistance)
        {
            _longDistanceImage.color = _currentActiveColor;
            _midDistanceImage.color = _currentActiveColor;
            _shortDistanceImage.color = _currentActiveColor;
        }

        if (distance > _shortDistance && distance < _midDistance)
        {
            _longDistanceImage.color = _currentActiveColor;
            _midDistanceImage.color = _currentActiveColor;
            _shortDistanceImage.color = _basicColor;
        }

        if (distance > _midDistance && distance < _longDistance)
        {
            _longDistanceImage.color = _currentActiveColor;
            _midDistanceImage.color = _basicColor;
            _shortDistanceImage.color = _basicColor;
        }

        if (distance > _longDistance)
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
