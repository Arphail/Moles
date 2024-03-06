using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(GoldFarmer))]
public class PlayerUpgrader : MonoBehaviour
{
    [SerializeField] private DataSaver _saver;
    [SerializeField] private LevelUpUI _ui;
    [SerializeField] private MoneyStash _base;
    [SerializeField] private int _speedMaxLevel;
    [SerializeField] private int _speedUpgradeCost;
    [SerializeField] private int _capacityMaxLevel;
    [SerializeField] private int _capacityUpgradeCost;
    [SerializeField] private int _delayMaxLevel;
    [SerializeField] private int _delayUpgradeCost;

    private GoldFarmer _farmer;
    private PlayerMovement _controller;
    private int _ugradeRatio = 15;
    private int _currentSpeedLevel = 1;
    private int _currentCapacityLevel = 1;
    private int _currentDelayLevel = 1;

    private void Start()
    {
        _farmer = GetComponent<GoldFarmer>();
        _controller = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _ui.ShowStats(_speedUpgradeCost, _capacityUpgradeCost, _delayUpgradeCost, _currentSpeedLevel, _speedMaxLevel, _currentCapacityLevel, _capacityMaxLevel, _currentDelayLevel, _delayMaxLevel);
    }

    public void BuyMoveSpeedUpgrade()
    {
        if (_currentSpeedLevel < _speedMaxLevel && _base.Money >= _speedUpgradeCost)
        {
            _base.SpendGold(_speedUpgradeCost);
            UpgradeMoveSpeed();
            _saver.SaveLevel(Constants.PlayerLevel, Constants.Speed, _currentSpeedLevel);
        }
    }

    public void UpgradeMoveSpeed(int level = 0)
    {
        _controller.MoveSpeedUpgrade();
        _currentSpeedLevel++;
        _speedUpgradeCost += _ugradeRatio;
    }

    public void BuyCapacityUpgrade()
    {
        if (_currentCapacityLevel < _capacityMaxLevel && _base.Money >= _capacityUpgradeCost)
        {
            _base.SpendGold(_capacityUpgradeCost);
            UpgradeGoldCapacity();
            _saver.SaveLevel(Constants.PlayerLevel, Constants.Capacity, _currentCapacityLevel);
        }
    }

    public void UpgradeGoldCapacity()
    {
        _farmer.UpgradeGoldCapacity();
        _currentCapacityLevel++;
        _capacityUpgradeCost += _ugradeRatio;
    }

    public void BuyDelayUpgrade()
    {
        if (_currentDelayLevel < _delayMaxLevel && _base.Money >= _delayUpgradeCost)
        {
            _base.SpendGold(_delayUpgradeCost);
            UpgradeFarmDelay();
            _saver.SaveLevel(Constants.PlayerLevel, Constants.Delay, _currentDelayLevel);
        }
    }

    public void UpgradeFarmDelay()
    {
        _farmer.UpgradeFarmDelay();
        _currentDelayLevel++;
        _delayUpgradeCost += _ugradeRatio;
    }
}