using UnityEngine;
using UnityEngine.Events;

public class Goldmine : MonoBehaviour
{
    [SerializeField] private GameObject _activationSignal;

    public event UnityAction<Goldmine> Activated;

    public bool IsActivated { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player) && IsActivated == false)
        {
            Activated?.Invoke(this);
            _activationSignal.SetActive(true);
            IsActivated = true;
        }
    }
}
