using System;
using System.Collections.Generic;
using System.Linq;
using Base;
using InteractiveObj.Barrier;
using InteractiveObj.Goldmine;
using LevelUppers;
using UnityEngine;

namespace Data
{
    [RequireComponent(typeof(DataSaver))]
    public class DataLoader : MonoBehaviour
    {
        [SerializeField] private List<Barrier> _barriers;
        [SerializeField] private List<Goldmine> _goldmines;
        [SerializeField] private MoneyStash _base;
        [SerializeField] private Tutorial.Tutorial _tutorial;
        [SerializeField] private MinionUpgrader _minionUpgrader;
        [SerializeField] private PlayerUpgrader _playerUpgrader;

        private DataSaver _saver;
        private Dictionary<string, Action> _saveStragiesByKey;

        private void Awake()
        {
            _saver = GetComponent<DataSaver>();

            _saveStragiesByKey = new Dictionary<string, Action>()
            {
                [Constants.PlayerMovespeedUpgradeKey] = () => _playerUpgrader.UpgradeMoveSpeed(),
                [Constants.PlayerCapacityUpgradeKey] = () => _playerUpgrader.UpgradeGoldCapacity(),
                [Constants.PlayerDelayUpgradeKey] = () => _playerUpgrader.UpgradeFarmDelay(),
                [Constants.MinionMovespeedUpgradeKey] = () => _minionUpgrader.UpgradeMoveSpeed(),
                [Constants.MinionCapacityUpgradeKey] = () => _minionUpgrader.UpgradeGoldCapacity(),
                [Constants.MinionDelayUpgradeKey] = () => _minionUpgrader.UpgradeFarmDelay(),
            };
            
            if (PlayerPrefs.HasKey(Constants.FirstTimePlaying) == false)
                PlayerPrefs.SetInt(Constants.FirstTimePlaying, Constants.PrefsTrue);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(Constants.FirstTimePlaying))
            {
                if (PlayerPrefs.GetInt(Constants.FirstTimePlaying) == Constants.PrefsTrue)
                {
                    _tutorial.gameObject.SetActive(true);
                    PlayerPrefs.SetInt(Constants.FirstTimePlaying, Constants.PrefsFalse);
                }
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
                string barrierPrefKey = Constants.Barrier + _saver.BarrierIds[i];
                
                if (PlayerPrefs.HasKey(barrierPrefKey))
                    if (PlayerPrefs.GetInt(barrierPrefKey) == Constants.PrefsTrue)
                        _barriers[i].Open();
                
            }
        }

        private void LoadGoldminesData()
        {
            for (int i = 0; i < _goldmines.Count; i++)
            {
                _saver.SetGoldmine(_goldmines[i].SerialNumber);
                string goldminePrefKey = Constants.Goldmine + _saver.GoldmineIds[i];

                if (PlayerPrefs.HasKey(goldminePrefKey))
                {
                    if (PlayerPrefs.GetInt(goldminePrefKey) == Constants.PrefsTrue)
                    {
                        _goldmines[i].ActivateGoldmine();

                        for (int j = 0; j < PlayerPrefs.GetInt(_saver.GoldmineLevels[i].ToString()); j++)
                            _goldmines[i].CatchLevels();
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
            foreach (var key in _saveStragiesByKey.Keys.Where(PlayerPrefs.HasKey))
                for (int i = 1; i < PlayerPrefs.GetInt(key); i++)
                    _saveStragiesByKey[key]?.Invoke();
        }
    }
}
