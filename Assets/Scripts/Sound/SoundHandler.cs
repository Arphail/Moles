using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    public void PlaySound() => _source.Play();
}
