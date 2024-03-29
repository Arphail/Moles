using System;
using Base;
using Data;
using LevelUppers;
using UnityEngine;

namespace InteractiveObj.Goldmine
{
    [RequireComponent(typeof(GoldmineUpgrader))]
    public class Goldmine : MonoBehaviour
    {
        [SerializeField] private MoneyStash _moneyStash;
        [SerializeField] private GoldmineUpgradeUi _ui;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private GoldmineModelChanger _animationHandler;
        [SerializeField] private GameObject _defaultModel;
        [SerializeField] private AudioSource _appearSound;
        [SerializeField] private AudioSource _upgradeSound;
        [SerializeField] private DataSaver _saver;
        [SerializeField] private int _serialNumber;

        private GoldmineUpgrader _upgrader;
        private int _levelCounter = 0;

        public event Action<Goldmine> Activated;

        public event Action<Goldmine> Upgraded;

        public bool IsActivated { get; private set; }

        public int SerialNumber => _serialNumber;

        private void Awake()
        {
            _upgrader = GetComponent<GoldmineUpgrader>();
            _defaultModel.SetActive(false);
            _particleSystem.Stop();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
            {
                if (IsActivated == false)
                    ActivateGoldmine();

                if (_upgrader.CurrentLevel < _upgrader.MaxLevel)
                {
                    _ui.gameObject.SetActive(true);
                    _ui.Button.onClick.AddListener(UpgradeGoldmine);
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<GoldFarmer.GoldFarmer>(out GoldFarmer.GoldFarmer farmer))
                farmer.StartFarm();

            if (other.TryGetComponent<Upgrader>(out Upgrader upgrader) && _ui.isActiveAndEnabled == true)
                _ui.ShowStats(_upgrader.CurrentLevel, _upgrader.MaxLevel, _upgrader.CurrentLevelCost);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<GoldFarmer.GoldFarmer>(out GoldFarmer.GoldFarmer farmer))
                farmer.StopFarm();

            if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
            {
                _ui.Button.onClick.RemoveListener(UpgradeGoldmine);
                _ui.gameObject.SetActive(false);
            }
        }

        public void UpgradeGoldmine()
        {
            if (_upgrader.CurrentLevel < _upgrader.MaxLevel && _moneyStash.Money >= _upgrader.CurrentLevelCost)
            {
                _moneyStash.SpendGold(_upgrader.CurrentLevelCost);
                _upgradeSound.Play();
                _animationHandler.ChangeToNextModel();
                _upgrader.UpgradeGoldmineMinionLimit();
                Upgraded?.Invoke(this);
                _levelCounter++;

                if (_levelCounter > PlayerPrefs.GetInt(_saver.GoldmineLevels[SerialNumber].ToString()))
                    _saver.SaveGoldmineLevel(SerialNumber, _levelCounter);
            }
        }

        public void CatchLevels()
        {
            _animationHandler.ChangeToNextModel();
            _upgrader.UpgradeGoldmineMinionLimit();
            Upgraded?.Invoke(this);
            _levelCounter++;
        }

        public void ActivateGoldmine()
        {
            _saver.SaveGoldmine(SerialNumber);
            _appearSound.Play();
            _defaultModel.SetActive(true);
            _particleSystem.Play();
            Activated?.Invoke(this);
            IsActivated = true;
        }
    }
}