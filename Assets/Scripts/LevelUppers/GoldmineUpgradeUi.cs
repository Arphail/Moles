using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class GoldmineUpgradeUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLevelVisual;
    [SerializeField] private TMP_Text _levelUpCost;
    [SerializeField] private Button _upgradeButton;

    public Button Button => _upgradeButton;

    public void ShowStats(int currentLevel, int maxLevel, int currentCost)
    {
        if (YandexGamesSdk.Environment.i18n.lang == "en")
            _currentLevelVisual.text = $"Level {currentLevel} / {maxLevel}";

        if (YandexGamesSdk.Environment.i18n.lang == "ru")
            _currentLevelVisual.text = $"Уровень {currentLevel} / {maxLevel}";

        if (YandexGamesSdk.Environment.i18n.lang == "tr")
            _currentLevelVisual.text = $"Seviye {currentLevel} / {maxLevel}";

        _levelUpCost.text = currentCost.ToString();

        if (currentLevel == maxLevel)
            _levelUpCost.text = "";
    }
}