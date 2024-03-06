using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelLogic
{
    public class LevelFinishingZone : MonoBehaviour
    {
        [SerializeField] private MoneyStash _base;
        [SerializeField] private int _cost;
        [SerializeField] private LevelFinishUi _ui;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player.Player>(out Player.Player player))
                _ui.Show();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player.Player>(out Player.Player player))
                _ui.Hide();
        }

        public void RestartLevel()
        {
            if (_base.Money >= _cost)
                ReloadLevel();
            else
                return;
        }

        private void ReloadLevel()
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
