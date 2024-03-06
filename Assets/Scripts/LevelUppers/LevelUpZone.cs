using UnityEngine;

namespace LevelUppers
{
    public class LevelUpZone : MonoBehaviour
    {
        [SerializeField] private LevelUpUI _ui;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player.Player>(out Player.Player player))
                _ui.gameObject.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player.Player>(out Player.Player player))
                _ui.gameObject.SetActive(false);
        }
    }
}
