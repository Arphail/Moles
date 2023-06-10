using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionUpgrader : MonoBehaviour, IUpgradable
{
    [SerializeField] private Minion[] _minions;
    [SerializeField] private LevelUpUI _ui;
    [SerializeField] private Base _base;
    [SerializeField] private int _speedUpgradeValue;
    [SerializeField] private float _speedMaxLevel;
    [SerializeField] private float _speedUpgradeCost;
    [SerializeField] private float _capacityMaxLevel;
    [SerializeField] private float _capacityUpgradeCost;
    [SerializeField] private float _delayMaxLevel;
    [SerializeField] private float _delayUpgradeCost;

    private float _ugradeRatio = 15;
    private float _currentSpeedLevel = 1;
    private float _currentCapacityLevel = 1;
    private float _currentDelayLevel = 1;

    private void Update()
    {
        _ui.ShowStats(_speedUpgradeCost, _capacityUpgradeCost, _delayUpgradeCost, _currentSpeedLevel, _speedMaxLevel, _currentCapacityLevel, _capacityMaxLevel, _currentDelayLevel, _delayMaxLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
            _ui.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
            _ui.gameObject.SetActive(false);
    }

    public void UpgradeMoveSpeed()
    {
        if (_currentSpeedLevel < _speedMaxLevel && _base.Gold >= _speedUpgradeCost)
        {
            foreach (var minion in _minions)
                minion.UpgradeMovementSpeed(_speedUpgradeValue);

            _base.SpendGold(_speedUpgradeCost);
            _speedUpgradeCost += _ugradeRatio;
            _currentSpeedLevel++;
        }
    }

    public void UpgradeGoldCapacity()
    {
        if (_currentCapacityLevel < _capacityMaxLevel && _base.Gold >= _capacityUpgradeCost)
        {
            foreach (var minion in _minions)
                minion.UpgradeCapacity();

            _base.SpendGold(_capacityUpgradeCost);
            _capacityUpgradeCost += _ugradeRatio;
            _currentCapacityLevel++;
        }
    }

    public void UpgradeFarmDelay()
    {
        if (_currentDelayLevel < _delayMaxLevel && _base.Gold >= _delayUpgradeCost)
        {
            foreach (var minion in _minions)
                minion.UpgradeDelay();

            _base.SpendGold(_delayUpgradeCost);
            _delayUpgradeCost += _ugradeRatio;
            _currentDelayLevel++;
        }
    }
}
