using UnityEngine;
using Agava.YandexGames;
using System;

public class AdHandler : MonoBehaviour
{
    public bool AdIsRunning { get; private set; }

    public void ShowRewardedVideo(Action onReward) => VideoAd.Show(OnAdOpen, onReward, OnAdClose);

    private void Start()
    {
        InterstitialAd.Show(OnAdOpen, OnInterstitialAdClose, null, null);
        AdIsRunning = true;
    }

    public void OnAdOpen()
    {
        AudioListener.volume = 0;
        Time.timeScale = 0;
        AdIsRunning = true;
    }

    private void OnAdClose()
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
        AdIsRunning = false;
    }

    private void OnInterstitialAdClose(bool b)
    {
        AudioListener.volume = 1;
        Time.timeScale = 1;
        AdIsRunning = false;
    }
}
