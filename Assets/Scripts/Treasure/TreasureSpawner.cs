using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Treasure[] _treasures;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private MinionSpawner _spawner;
    [SerializeField] private float _treasureDelay;
    [SerializeField] private float _goldDropChance;
    [SerializeField] private float _moleDropChance;
    [SerializeField] private float _skinDropChance;

    private int _randomPositionIndex;
    private float _currentTimePassed = 0;
    private float _treasureChanceProc;
    private bool _isSpawned;
    private Treasure _treasureToSpawn;
    private Treasure _goldTreasure;
    private Treasure _moleTreasure;
    private Treasure _skinTreasure;

    public int AccquiredTreasure { get; private set; }

    private void Start()
    {

        foreach(var treasure in _treasures)
        {
            if (treasure is GoldTreasure)
                _goldTreasure = treasure;

            if (treasure is MoleTreasure)
                _moleTreasure = treasure;

            if (treasure is SkinTreasure)
                _skinTreasure = treasure;
        }
    }

    private void OnEnable()
    {
        foreach (var treasure in _treasures)
            treasure.Accquired += OnTreasureAcquired;
    }

    private void OnDisable()
    {
        foreach (var treasure in _treasures)
            treasure.Accquired -= OnTreasureAcquired;
    }

    private void Update()
    {
        if (_spawner.CanSpawn)
        {
            _currentTimePassed += Time.deltaTime;

            if (_currentTimePassed >= _treasureDelay && _isSpawned == false)
            {
                _randomPositionIndex = Random.Range(0, _spawnPositions.Length - 1);
                _treasureChanceProc = Random.Range(0, 100);
                print(_treasureChanceProc);

                if (_treasureChanceProc <= _goldDropChance)
                    _treasureToSpawn = _goldTreasure;

                else if (_treasureChanceProc <= _moleDropChance && _treasureChanceProc > _goldDropChance)
                    _treasureToSpawn = _moleTreasure;

                else if (_treasureChanceProc <= _skinDropChance && _treasureChanceProc > _moleDropChance)
                    _treasureToSpawn = _skinTreasure;

                print(_treasureToSpawn.gameObject.name);

                SpawnTreasure(_treasureToSpawn, _spawnPositions[_randomPositionIndex]);
                _isSpawned = true;
            }
        }
    }

    private void SpawnTreasure(Treasure treasure, Transform spawnPosition)
    {
        treasure.gameObject.SetActive(true);
        treasure.SetPosition(spawnPosition);
    }

    private void OnTreasureAcquired()
    {
        _isSpawned = false;
        _currentTimePassed = 0;
        AccquiredTreasure++;
    }
}
