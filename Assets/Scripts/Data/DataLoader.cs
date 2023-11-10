using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DataSaver))]
public class DataLoader : MonoBehaviour
{
    [SerializeField] private List<Barrier> _barriers;
    [SerializeField] private List<Goldmine> _goldmines;
    [SerializeField] private Base _base;
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private MinionUpgrader _minionUpgrader;
    [SerializeField] private PlayerUpgrader _playerUpgrader;

    private DataSaver _saver;

    private void Awake()
    {
        _saver = GetComponent<DataSaver>();

        if (PlayerPrefs.HasKey(Constants.FirstTimePlaying) == false)
            PlayerPrefs.SetInt(Constants.FirstTimePlaying, 1);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(Constants.FirstTimePlaying))
            if (PlayerPrefs.GetInt(Constants.FirstTimePlaying) == 1)
            {
                _tutorial.gameObject.SetActive(true);
                PlayerPrefs.SetInt(Constants.FirstTimePlaying, 0);
            }

        LoadBarriersData();
        LoadMoneyData();
        LoadGoldminesData();
        LoadUpgradesData();
    }

    private void LoadBarriersData()
    {
        for (int i = 0; i < _barriers.Count; i++)
        {
            _saver.SetBarrier(_barriers[i].SerialNumber);

            if (PlayerPrefs.HasKey(Constants.Barrier + _saver.BarrierNumbers[i].ToString()))
                if (PlayerPrefs.GetInt(Constants.Barrier + _saver.BarrierNumbers[i].ToString()) == 1)
                    _barriers[i].Open();
        }
    }

    private void LoadGoldminesData()
    {
        for(int i = 0; i < _goldmines.Count; i++)
        {
            _saver.SetGoldmine(_goldmines[i].SerialNumber);

            if(PlayerPrefs.HasKey(Constants.Goldmine + _saver.GoldmineNumbers[i].ToString()))
            {
                if (PlayerPrefs.GetInt(Constants.Goldmine + _saver.GoldmineNumbers[i].ToString()) == 1)
                {
                    _goldmines[i].ActivateGoldmine();

                    for (int j = 0; j < PlayerPrefs.GetInt(_saver.GoldmineLevels[i].ToString()); j++)
                    {
                        _goldmines[i].CatchLevels();
                    }
                }
            }
        }
    }

    private void LoadMoneyData()
    {
        if (PlayerPrefs.HasKey(Constants.Money))
            _base.AddGold(PlayerPrefs.GetFloat(Constants.Money));
    } 

    private void LoadUpgradesData()
    {
        if (PlayerPrefs.HasKey(Constants.PlayerLevel + Constants.Speed))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.PlayerLevel + Constants.Speed); i++)
                _playerUpgrader.UpgradeMoveSpeed();

        if (PlayerPrefs.HasKey(Constants.PlayerLevel + Constants.Capacity))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.PlayerLevel + Constants.Capacity); i++)
                _playerUpgrader.UpgradeGoldCapacity();

        if (PlayerPrefs.HasKey(Constants.PlayerLevel + Constants.Delay))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.PlayerLevel + Constants.Delay); i++)
                _playerUpgrader.UpgradeFarmDelay();

        if (PlayerPrefs.HasKey(Constants.MinionLevel + Constants.Speed))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.MinionLevel + Constants.Speed); i++)
                _minionUpgrader.UpgradeMoveSpeed();

        if (PlayerPrefs.HasKey(Constants.MinionLevel + Constants.Capacity))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.MinionLevel + Constants.Capacity); i++)
                _minionUpgrader.UpgradeGoldCapacity();

        if (PlayerPrefs.HasKey(Constants.MinionLevel + Constants.Delay))
            for (int i = 1; i < PlayerPrefs.GetInt(Constants.MinionLevel + Constants.Delay); i++)
                _minionUpgrader.UpgradeFarmDelay();
    }
}
