using Player;
using UnityEngine;

namespace Portal
{
    public class PortalToBase : MonoBehaviour
    {
        [SerializeField] private Transform _base;
        [SerializeField] private AudioSource _audioSource;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerTeleporter>(out PlayerTeleporter teleporter))
            {
                _audioSource.Play();
                teleporter.Teleport(_base.position);
            }
        }
    }
}
