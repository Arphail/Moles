using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GoldmineUpgrader))]
public class Goldmine : MonoBehaviour
{
    [SerializeField] private MoneyStash _moneyStash;
    [SerializeField] private GoldmineUpgradeUi _ui;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GoldmineModelChanger _animationHandler;
    [SerializeField] private GameObject _level0Model;
    [SerializeField] private AudioSource _appearSound;
    [SerializeField] private AudioSource _upgradeSound;
    [SerializeField] private DataSaver _saver;
    [SerializeField] private int _serialNumber;

    private GoldmineUpgrader _upgrader;
    private int LevelCounter = 0;

    public event Action<Goldmine> Activated;

    public event Action<Goldmine> Upgraded;

    public bool IsActivated { get; private set; }

    public int SerialNumber => _serialNumber;

    private void Awake()
    {
        _upgrader = GetComponent<GoldmineUpgrader>();
        _level0Model.SetActive(false);
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
        if (other.TryGetComponent<GoldFarmer>(out GoldFarmer farmer))
            farmer.StartFarm();

        if (other.TryGetComponent<Upgrader>(out Upgrader upgrader) && _ui.isActiveAndEnabled == true)
            _ui.ShowStats(_upgrader.CurrentLevel, _upgrader.MaxLevel, _upgrader.CurrentLevelCost);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<GoldFarmer>(out GoldFarmer farmer))
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
            _animationHandler.ChangeModel();
            _upgrader.UpgradeGoldmineMinionLimit();
            Upgraded?.Invoke(this);
            LevelCounter++;

            if (LevelCounter > PlayerPrefs.GetInt(_saver.GoldmineLevels[SerialNumber].ToString()))
                _saver.SaveGoldmineLevel(SerialNumber, LevelCounter);
        }
    }

    public void CatchLevels()
    {
        _animationHandler.ChangeModel();
        _upgrader.UpgradeGoldmineMinionLimit();
        Upgraded?.Invoke(this);
        LevelCounter++;
    }

    public void ActivateGoldmine()
    {
        _saver.SaveGoldmine(SerialNumber);
        _appearSound.Play();
        _level0Model.SetActive(true);
        _particleSystem.Play();
        Activated?.Invoke(this);
        IsActivated = true;
    }
}