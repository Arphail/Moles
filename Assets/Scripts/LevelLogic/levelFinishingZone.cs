using UnityEngine;
using UnityEngine.SceneManagement;

public class levelFinishingZone : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private int _cost;
    [SerializeField] private LevelFinishUi _ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _ui.ShowUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            _ui.HideUI();
        }
    }

    public void ReloadLevel()
    {
        if (_base.Money >= _cost)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
