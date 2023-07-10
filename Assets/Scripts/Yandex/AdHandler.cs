using UnityEngine;
using Agava.YandexGames;

public class AdHandler : MonoBehaviour
{
    public void ShowRewardedVideo() => VideoAd.Show(OnAdOpen, null, OnAdClose);

    public void OnAdOpen()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    private void OnAdClose()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
    }
}
