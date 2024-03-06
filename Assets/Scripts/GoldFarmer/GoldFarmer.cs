using System.Collections;
using UnityEngine;

namespace GoldFarmer
{
    [RequireComponent(typeof(GoldStacker))]
    public class GoldFarmer : MonoBehaviour
    {
        [SerializeField] private int _goldCapacity;
        [SerializeField] private int _goldCapacityUpgrade;
        [SerializeField] private float _delayTime;
        [SerializeField] private float _farmDelayUpgrade;

        private GoldStacker _stacker;
        private WaitForSeconds _farmDelay;
        private Coroutine _farmingCoroutine;
        private int _currentGold = 0;

        public int CurrentGold => _currentGold;

        public int GoldCapacity => _goldCapacity;

        private void Awake()
        {
            _stacker = GetComponent<GoldStacker>();
        }

        private void Start()
        {
            _farmDelay = new WaitForSeconds(_delayTime);
        }

        public void EmptyBag()
        {
            _currentGold = 0;
            _stacker.EmptyStacks();
        }

        public void StartFarm()
        {
            if (_farmingCoroutine == null)
                _farmingCoroutine = StartCoroutine(FarmGold());
        }

        public void StopFarm()
        {
            if (_farmingCoroutine != null)
            {
                StopCoroutine(_farmingCoroutine);
                _farmingCoroutine = null;
            }
        }

        public void UpgradeFarmDelay()
        {
            _delayTime -= _farmDelayUpgrade;
            _farmDelay = new WaitForSeconds(_delayTime);
        }

        public void UpgradeGoldCapacity() => _goldCapacity += _goldCapacityUpgrade;

        private IEnumerator FarmGold()
        {
            yield return _farmDelay;

            while (_currentGold < _goldCapacity)
            {
                _currentGold++;
                _stacker.StackGold();
                yield return _farmDelay;
            }
        }
    }
}
