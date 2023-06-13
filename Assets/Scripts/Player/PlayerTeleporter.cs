using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public void Teleport(Vector3 targetPosition) => transform.position = targetPosition;
}
