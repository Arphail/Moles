using System.Collections.Generic;
using InteractiveObj.Goldmine;
using UnityEngine;

namespace Minions
{
    public class MinionSpawner : MonoBehaviour
    {
        [SerializeField] private Goldmine[] _goldmines;
        [SerializeField] private Minion[] _minionPool;
        [SerializeField] private Transform _spawnPoint;

        private List<Goldmine> _activatedGoldmines;

        private void Awake()
        {
            _activatedGoldmines = new List<Goldmine>();
        }

        private void OnEnable()
        {
            foreach (var goldmine in _goldmines)
            {
                goldmine.Activated += OnGoldMineActivated;
                goldmine.Upgraded += OnGoldMineUpgraded;
            }
        }

        private void OnDisable()
        {
            foreach (var goldmine in _goldmines)
            {
                goldmine.Activated -= OnGoldMineActivated;
                goldmine.Upgraded -= OnGoldMineUpgraded;
            }
        }
        
        private void SpawnMinion(Goldmine goldmine)
        {
            foreach (Minion minion in _minionPool)
            {
                if (minion.isActiveAndEnabled == false)
                {
                    minion.gameObject.SetActive(true);
                    minion.SetBase(_spawnPoint.position);
                    minion.SetGoldmine(goldmine.transform.position);
                    return;
                }
            }
        }

        private void OnGoldMineActivated(Goldmine goldmine)
        {
            _activatedGoldmines.Add(goldmine);
            SpawnMinion(goldmine);
        }

        private void OnGoldMineUpgraded(Goldmine goldmine)
        {
            SpawnMinion(goldmine);
        }
    }
}
