using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Goldmine[] _goldmines;
    [SerializeField] private Treasure _treasureTemplate;
    [SerializeField] private int _delaySeconds;

    private WaitForSeconds _delay;
    private Coroutine _spawnWithDelay;
    private Treasure _spawnedTreasure;
    private int _activatedGoldmines;
    private bool _isSpawned;

    private void Start()
    {
        _delay = new WaitForSeconds(_delaySeconds);
    }

    private void OnEnable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated += OnGoldmineActivated;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
            if (_activatedGoldmines == _goldmines.Length && _isSpawned == false && _spawnWithDelay == null)
                _spawnWithDelay = StartCoroutine(SpawnWithDelay(player.transform));
    }

    private IEnumerator SpawnWithDelay(Transform player)
    {
        yield return _delay;
        Vector3 randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position;

        if (_spawnedTreasure == null)
        {
            _spawnedTreasure = Instantiate(_treasureTemplate, randomSpawnPoint, Quaternion.identity);
        }
        else
        {
            _spawnedTreasure.gameObject.SetActive(true);
            _spawnedTreasure.transform.position = randomSpawnPoint;
        }

        _spawnedTreasure.transform.LookAt(player);
        _spawnedTreasure.PickedUp += OnTreasurePickUp;
        print("Spawned!");
        _isSpawned = true;
        _spawnWithDelay = null; 
    }

    private void OnTreasurePickUp(Treasure treasure)
    {
        _isSpawned = false;
        treasure.PickedUp -= OnTreasurePickUp;
    }

    private void OnGoldmineActivated(Goldmine goldmine)
    {
        _activatedGoldmines++;
        goldmine.Activated -= OnGoldmineActivated;
    }
}
