using UnityEngine;
using UnityEngine.UI;

public class SoundIconChanger : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _muted;
    [SerializeField] private Sprite _unMuted;

    private bool _isMuted;

    public void ChangeIcon()
    {
        if (_isMuted)
        {
            _icon.sprite = _unMuted;
            _isMuted = false;
        }
        else
        {
            _icon.sprite = _muted;
            _isMuted = true;
        }
    }
}
