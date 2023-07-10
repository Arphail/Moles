using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldmineUpgradeUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevelVisual;
    [SerializeField] private TMP_Text _levelUpCost;
    [SerializeField] private Button _upgradeButton;

    public Button Button => _upgradeButton;

    public void ShowStats(int currentLevel, int maxLevel, int currentCost)
    {
        _currentLevelVisual.text = $"Level {currentLevel.ToString()} / {maxLevel}";
        _levelUpCost.text = currentCost.ToString();

        if (currentLevel == maxLevel)
            _levelUpCost.text = "";
    }
}