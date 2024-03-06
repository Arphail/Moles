using System;
using UnityEngine;

public class MoneyForAdButton : MonoBehaviour
{
    [SerializeField] private AdHandler _handler;
    [SerializeField] private MoneyStash _base;
    [SerializeField] private int _reward;

    public void GiveMoneyForAd() => _handler.ShowRewardedVideo(GiveMoney);

    private void GiveMoney() => _base.AddGold(_reward);
}
