using UnityEngine;
using Agava.YandexGames;
using System;

public class AdHandler : MonoBehaviour
{
    public void ShowRewardedVideo(Action onReward) => VideoAd.Show(OnAdOpen, onReward, OnAdClose);

    public void ShowInterstitialVideo(Action onReward) => VideoAd.Show(OnAdOpen, onReward, OnAdClose);

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
