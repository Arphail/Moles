using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    public void Teleport(Vector3 targetPosition) => _playerTransform.SetPositionAndRotation(targetPosition, Quaternion.identity);
}
