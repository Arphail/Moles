using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private float _xRect;
    [SerializeField] private float _yRect;

    private void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(_xRect, _yRect) * Time.deltaTime, _image.uvRect.size);
    }
}
