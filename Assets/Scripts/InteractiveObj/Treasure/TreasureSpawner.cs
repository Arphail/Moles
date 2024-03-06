using System.Collections;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Goldmine[] _goldmines;
    [SerializeField] private Treasure _treasureTemplate;
    [SerializeField] private Radar _radar;
    [SerializeField] private GameObject _treasureAlertUI;
    [SerializeField] private MoneyStash _base;
    [SerializeField] private int _delaySeconds;
    [SerializeField] private int _money;
    [SerializeField] private LeaderBoardScoreSetter _scoreSetter;

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

    private void OnDisable()
    {
        foreach (var goldmine in _goldmines)
            goldmine.Activated -= OnGoldmineActivated;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (_isSpawned)
                _treasureAlertUI.SetActive(true);
            else
                _treasureAlertUI.SetActive(false);

            if (_activatedGoldmines == _goldmines.Length)
            {
                _radar.SetTreasureMode();

                if (_isSpawned == false && _spawnWithDelay == null)
                    _spawnWithDelay = StartCoroutine(SpawnWithDelay(player.transform));
            }
            else if (_activatedGoldmines != _goldmines.Length)
            {
                _treasureAlertUI.SetActive(false);
                _radar.SetGoldmineMode();
            }
        }
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
        _isSpawned = true;
        _spawnWithDelay = null;
    }

    private void OnTreasurePickUp(Treasure treasure)
    {
        _isSpawned = false;
        _base.AddGold(_money);
        _scoreSetter.SetPlayerScore();
        treasure.PickedUp -= OnTreasurePickUp;
    }

    private void OnGoldmineActivated(Goldmine goldmine)
    {
        _activatedGoldmines++;
        goldmine.Activated -= OnGoldmineActivated;
    }
}
