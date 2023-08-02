using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;

public class levelFinishingZone : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private int _cost;
    [SerializeField] private LevelFinishUi _ui;
    [SerializeField] private AdHandler _adHandler;

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

    public void RestartLevel()
    {
        if (_base.Money >= _cost)
            _adHandler.ShowInterstitialVideo(ReloadLevel);
        else
            return;
    }

    private void ReloadLevel()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
