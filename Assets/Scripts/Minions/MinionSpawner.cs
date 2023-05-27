using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] private Goldmine[] _goldmines;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _base;

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
    }

    private void OnDisable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated -= OnGoldMineActivated;
    }

    public void SpawnMinion(Minion minionTemplate)
    {
        if (_activatedGoldmines.Count > 0)
        {
            Minion spawnedMinion = Instantiate(minionTemplate, _spawnPoint.position, Quaternion.identity);
            int randomGoldmineIndex = Random.Range(0, _activatedGoldmines.Count);
            spawnedMinion.SetBase(_base.transform.position);
            spawnedMinion.SetGoldmine(_activatedGoldmines[randomGoldmineIndex].transform.position);
            SpawnedMinions++;
        }
        else
        {
            print("There is no activated goldmines");
        }
    }

    private void OnGoldMineActivated(Goldmine goldmine)
    {
        _activatedGoldmines.Add(goldmine);
        CanSpawn = true;
    }
}
