using UnityEngine;

namespace LevelUppers
{
    public class GoldmineUpgrader : MonoBehaviour
    {
        [SerializeField] private int _maxLevel;
        [SerializeField] private int _levelUpCost;
        [SerializeField] private int _costRatio;

        public int MaxLevel => _maxLevel;

        public int CurrentLevel { get; private set; }

        public int CurrentLevelCost { get; private set; }

        private void Awake()
        {
            CurrentLevelCost = _levelUpCost;
            CurrentLevel = 0;
        }

        public void UpgradeGoldmineMinionLimit()
        {
            CurrentLevel++;
            CurrentLevelCost += _costRatio;
        }
    }
}
