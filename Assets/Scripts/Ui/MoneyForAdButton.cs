using UnityEngine;
using System;

public class MoneyForAdButton : MonoBehaviour
{
    [SerializeField] private AdHandler _handler;
    [SerializeField] private Base _base;
    [SerializeField] private int _reward;

    private Action _giveMoney;

    private void Start()
    {
        _giveMoney = GiveMoney;
    }

    public void GiveMoneyForAd() => _handler.ShowRewardedVideo(GiveMoney);

    private void GiveMoney() => _base.AddGold(_reward);
}
