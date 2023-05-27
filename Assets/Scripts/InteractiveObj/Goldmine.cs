using UnityEngine;
using UnityEngine.Events;

public class Goldmine : MonoBehaviour
{
    public event UnityAction<Goldmine> Activated;

    public bool IsActivated { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player) && IsActivated == false)
        {
            Activated?.Invoke(this);
            IsActivated = true;
        }
    }
}
