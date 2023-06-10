using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private Goldmine[] _goldmines;
    [SerializeField] private Minion[] _minionPool;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _returnPoint;

    private List<Goldmine> _activatedGoldmines;

    public bool CanSpawn { get; private set; }

    public int SpawnedMinions { get; private set; }

    private void Start()
    {
        _activatedGoldmines = new List<Goldmine>();
    }

    private void OnEnable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated += OnGoldMineActivated;

        foreach (var goldmine in _goldmines)
            goldmine.Upgraded += OnGoldMineUpgraded;
    }

    private void OnDisable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated -= OnGoldMineActivated;

        foreach (var goldmine in _goldmines)
            goldmine.Upgraded -= OnGoldMineUpgraded;
    }

    private void Update()
    {
        if (_activatedGoldmines.Count > 0)
            CanSpawn = true;
        else
            CanSpawn = false;
    }

    public void SpawnMinion(Goldmine goldmine)
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
    }

    private void OnGoldMineUpgraded(Goldmine goldmine)
    {
        SpawnMinion(goldmine);
    }
}
