using System.Collections;
using UnityEngine;

public class BackGroundMusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private WaitForSeconds _waitUntillMusicEnds;
    private Coroutine _musicPlayer;

    private void Start()
    {
        if (_musicPlayer == null)
            _musicPlayer = StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            _waitUntillMusicEnds = new WaitForSeconds(_source.clip.length);
            _source.Play();
            yield return _waitUntillMusicEnds;
        }
    }
}
