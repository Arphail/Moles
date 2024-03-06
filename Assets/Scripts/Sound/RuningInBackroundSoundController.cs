using Agava.WebUtility;
using UnityEngine;
using Yandex;

namespace Sound
{
    public class RuningInBackroundSoundController : MonoBehaviour
    {
        [SerializeField] private AdHandler _adHandler;

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if (_adHandler.AdIsRunning == false)
            {
                AudioListener.pause = inBackground;
                AudioListener.volume = inBackground ? 0f : 1f;
            }
        }
    }
}
