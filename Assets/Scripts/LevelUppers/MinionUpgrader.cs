using UnityEngine;

public class MinionUpgrader : MonoBehaviour, IUpgradable
{
    [SerializeField] private DataSaver _saver;
    [SerializeField] private Minion[] _minions;
    [SerializeField] private LevelUpUI _ui;
    [SerializeField] private Base _base;
    [SerializeField] private int _speedUpgradeValue;
    [SerializeField] private int _speedMaxLevel;
    [SerializeField] private int _speedUpgradeCost;
    [SerializeField] private int _capacityMaxLevel;
    [SerializeField] private int _capacityUpgradeCost;
    [SerializeField] private int _delayMaxLevel;
    [SerializeField] private int _delayUpgradeCost;

    private int _ugradeRatio = 15;
    private int _currentSpeedLevel = 1;
    private int _currentCapacityLevel = 1;
    private int _currentDelayLevel = 1;

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

    public void BuyMoveSpeedUpgrade()
    {
        if (_currentSpeedLevel < _speedMaxLevel && _base.Money >= _speedUpgradeCost)
        {
            _base.SpendGold(_speedUpgradeCost);
            UpgradeMoveSpeed();
            _saver.SaveLevel(Constants.MinionLevel, Constants.Speed, _currentSpeedLevel);
        }
    }

    public void UpgradeMoveSpeed()
    {
        foreach (var minion in _minions)
            minion.UpgradeMovementSpeed(_speedUpgradeValue);

        _speedUpgradeCost += _ugradeRatio;
        _currentSpeedLevel++;
    }

    public void BuyCapacityUpgrade()
    {
        if (_currentCapacityLevel < _capacityMaxLevel && _base.Money >= _capacityUpgradeCost)
        {
            _base.SpendGold(_capacityUpgradeCost);
            UpgradeGoldCapacity();
            _saver.SaveLevel(Constants.MinionLevel, Constants.Capacity, _currentCapacityLevel);
        }
    }

    public void UpgradeGoldCapacity()
    {
        foreach (var minion in _minions)
            minion.UpgradeCapacity();

        _capacityUpgradeCost += _ugradeRatio;
        _currentCapacityLevel++;
    }

    public void BuyDelayUpgrade()
    {
        if (_currentDelayLevel < _delayMaxLevel && _base.Money >= _delayUpgradeCost)
        {
            _base.SpendGold(_delayUpgradeCost);
            UpgradeFarmDelay();
            _saver.SaveLevel(Constants.MinionLevel, Constants.Delay, _currentDelayLevel);
        }
    }

    public void UpgradeFarmDelay()
    {
        foreach (var minion in _minions)
            minion.UpgradeDelay();

        _delayUpgradeCost += _ugradeRatio;
        _currentDelayLevel++;
    }
}
