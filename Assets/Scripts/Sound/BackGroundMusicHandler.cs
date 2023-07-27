using System.Collections;
using UnityEngine;

public class BackGroundMusicHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _backgroundMusicSamples;

    private WaitForSeconds _waitUntillMusicEnds;
    private AudioClip _currentMusic;
    private Coroutine _musicPlayer;
    private int _currentIndex;
    private int _lastIndex;
    private bool _isFirstTimePlaying;

    private void Start()
    {
        _isFirstTimePlaying = true;

        if (_musicPlayer == null)
            _musicPlayer = StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        while (true)
        {
            SetRandomIndex();
            _currentMusic = _backgroundMusicSamples[_currentIndex];
            _source.clip = _currentMusic;
            _waitUntillMusicEnds = new WaitForSeconds(_currentMusic.length);
            _source.Play();
            yield return _waitUntillMusicEnds;
        }
    }

    private void SetRandomIndex()
    {
        if (_isFirstTimePlaying)
        {
            _currentIndex = Random.Range(0, _backgroundMusicSamples.Length);
            _isFirstTimePlaying = false; 
            return;
        }
        else
        {
            while (_currentIndex == _lastIndex)
                _currentIndex = Random.Range(0, _backgroundMusicSamples.Length);
        }
        _lastIndex = _currentIndex;
    }
}
