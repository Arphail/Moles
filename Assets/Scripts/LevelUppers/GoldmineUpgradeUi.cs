using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LevelUppers
{
    public class GoldmineUpgradeUi : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentLevelVisual;
        [SerializeField] private TMP_Text _levelUpCost;
        [SerializeField] private Button _upgradeButton;

        public Button Button => _upgradeButton;

        public void ShowStats(int currentLevel, int maxLevel, int currentCost)
        {
            if (YandexGamesSdk.Environment.i18n.lang == "en")
                _currentLevelVisual.text = $"Level\n{currentLevel} / {maxLevel}";

            if (YandexGamesSdk.Environment.i18n.lang == "ru")
                _currentLevelVisual.text = $"Уровень\n{currentLevel} / {maxLevel}";

            if (YandexGamesSdk.Environment.i18n.lang == "tr")
                _currentLevelVisual.text = $"Seviye\n{currentLevel} / {maxLevel}";

            _levelUpCost.text = currentCost.ToString();

            if (currentLevel == maxLevel)
                _levelUpCost.text = string.Empty;
        }
    }
}