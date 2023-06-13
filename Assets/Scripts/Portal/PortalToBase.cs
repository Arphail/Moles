using UnityEngine;

public class PortalToBase : MonoBehaviour
{
    [SerializeField] private Transform _base;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerTeleporter>(out PlayerTeleporter teleporter))
            teleporter.Teleport(_base.position);
    }
}
