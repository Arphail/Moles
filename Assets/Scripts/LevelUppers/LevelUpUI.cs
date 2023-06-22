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
        _currentSpeedLevelVisual.text = $"Speed level {currentSpeedLevel} / {maxSpeedLevel}";
        _currentSpeedUpgradeCost.text = speedCost.ToString();
        _currentCapacityLevelVisual.text = $"Capacity level {currentCapacityLevel} / {maxCapacityLevel}";
        _currentCapacityUpgradeCost.text = capacityCost.ToString();
        _currentDelayLevelVisual.text = $"Delay level {currentDelayLevel} / {maxDelayLevel}";
        _currentDelayUpgradeCost.text = delayCost.ToString();

        if(currentSpeedLevel == maxSpeedLevel)
            _currentSpeedUpgradeCost.text = "";

        if (currentCapacityLevel == maxCapacityLevel)
            _currentCapacityUpgradeCost.text = "";

        if (currentDelayLevel == maxDelayLevel)
            _currentDelayUpgradeCost.text = "";
    }
}
