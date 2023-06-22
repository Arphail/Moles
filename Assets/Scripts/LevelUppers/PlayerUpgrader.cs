using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GoldFarmer))]
public class PlayerUpgrader : MonoBehaviour, IUpgradable
{
    [SerializeField] private LevelUpUI _ui;
    [SerializeField] private Base _base;
    [SerializeField] private float _speedMaxLevel;
    [SerializeField] private float _speedUpgradeCost;
    [SerializeField] private float _capacityMaxLevel;
    [SerializeField] private float _capacityUpgradeCost;
    [SerializeField] private float _delayMaxLevel;
    [SerializeField] private float _delayUpgradeCost;

    private GoldFarmer _farmer;
    private PlayerController _controller;
    private float _ugradeRatio = 15;
    private float _currentSpeedLevel = 1;
    private float _currentCapacityLevel = 1;
    private float _currentDelayLevel = 1;

    private void Start()
    {
        _farmer = GetComponent<GoldFarmer>();
        _controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        _ui.ShowStats(_speedUpgradeCost, _capacityUpgradeCost, _delayUpgradeCost, _currentSpeedLevel, _speedMaxLevel, _currentCapacityLevel, _capacityMaxLevel, _currentDelayLevel, _delayMaxLevel);
    }

    public void UpgradeMoveSpeed()
    {
        if (_currentSpeedLevel < _speedMaxLevel && _base.Gold >= _speedUpgradeCost)
        {
            _controller.MoveSpeedUpgrade();
            _base.SpendGold(_speedUpgradeCost);
            _currentSpeedLevel++;
            _speedUpgradeCost +=  _ugradeRatio;
        }
    }

    public void UpgradeGoldCapacity()
    {
        if (_currentCapacityLevel < _capacityMaxLevel && _base.Gold >= _capacityUpgradeCost)
        {
            _farmer.UpgradeGoldCapacity();
            _base.SpendGold(_capacityUpgradeCost);
            _currentCapacityLevel++;
            _capacityUpgradeCost += _ugradeRatio;
        }
    }

    public void UpgradeFarmDelay()
    {
        if (_currentDelayLevel < _delayMaxLevel && _base.Gold >= _delayUpgradeCost)
        {
            _farmer.UpgradeFarmDelay();
            _base.SpendGold(_delayUpgradeCost);
            _currentDelayLevel++;
            _delayUpgradeCost += _ugradeRatio;
        }
    }
}