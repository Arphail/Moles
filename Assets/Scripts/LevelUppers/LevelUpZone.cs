using UnityEngine;

public class LevelUpZone : MonoBehaviour
{
    [SerializeField] private LevelUpUI _ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _ui.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _ui.gameObject.SetActive(false);
    }
}
