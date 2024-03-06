using System;
using TMPro;
using UnityEngine;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentSpeedLevelVisual;
    [SerializeField] private TMP_Text _currentSpeedUpgradeCost;
    [SerializeField] private TMP_Text _currentCapacityLevelVisual;
    [SerializeField] private TMP_Text _currentCapacityUpgradeCost;
    [SerializeField] private TMP_Text _currentDelayLevelVisual;
    [SerializeField] private TMP_Text _currentDelayUpgradeCost;

    public void ShowStats(float speedCost, float capacityCost, float delayCost, float currentSpeedLevel, float maxSpeedLevel, float currentCapacityLevel, float maxCapacityLevel, float currentDelayLevel, float maxDelayLevel)
    {
        _currentSpeedLevelVisual.text = $"{currentSpeedLevel} / {maxSpeedLevel}";
        _currentSpeedUpgradeCost.text = speedCost.ToString();
        _currentCapacityLevelVisual.text = $"{currentCapacityLevel} / {maxCapacityLevel}";
        _currentCapacityUpgradeCost.text = capacityCost.ToString();
        _currentDelayLevelVisual.text = $"{currentDelayLevel} / {maxDelayLevel}";
        _currentDelayUpgradeCost.text = delayCost.ToString();

        if (Math.Abs(currentSpeedLevel - maxSpeedLevel) < float.Epsilon)
            _currentSpeedUpgradeCost.text = string.Empty;

        if (Math.Abs(currentCapacityLevel - maxCapacityLevel) < float.Epsilon)
            _currentCapacityUpgradeCost.text = string.Empty;

        if (Math.Abs(currentDelayLevel - maxDelayLevel) < float.Epsilon)
            _currentDelayUpgradeCost.text = string.Empty;
    }
}
