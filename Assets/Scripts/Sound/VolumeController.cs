using UnityEngine;

public class VolumeController : MonoBehaviour
{
    private bool _isMuted;

    public void ChangeVolume()
    {
        if (_isMuted)
        {
            AudioListener.volume = 1;
            _isMuted = false;
        }
        else
        {
            AudioListener.volume = 0;
            _isMuted = true;
        }
    }
}
