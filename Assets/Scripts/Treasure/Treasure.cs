using UnityEngine;
using UnityEngine.Events;

public abstract class Treasure : MonoBehaviour
{
    public abstract event UnityAction Accquired;
    public abstract void AccquireTreasure();
    public abstract void SetPosition(Transform transform);
}
