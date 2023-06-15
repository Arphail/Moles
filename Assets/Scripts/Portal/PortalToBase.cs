using UnityEngine;

public class PortalToBase : MonoBehaviour
{
    [SerializeField] private Transform _base;
    [SerializeField] private SoundHandler _soundHandler;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerTeleporter>(out PlayerTeleporter teleporter))
        {
            _soundHandler.PlaySound();
            teleporter.Teleport(_base.position);
        }
    }
}
