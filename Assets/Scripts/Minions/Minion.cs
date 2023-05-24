using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GoldStacker _stacker;
    [SerializeField] private float _goldCapacity;
    [SerializeField] private float _delayTime;

    private WaitForSeconds _farmDelay;
    private Vector3 _basePosition;
    private Vector3 _goldminePosition;
    private int _currentGold = 0;
    private bool _isFarming;

    public int CurrentGold => _currentGold;

    public Vector3 GoldminePosition => _goldminePosition;

    private void Start()
    {
        _farmDelay = new WaitForSeconds(_delayTime);
    }

    public void SetBase(Vector3 basePosition) => _basePosition = basePosition;

    public void SetGoldmine(Vector3 goldminePosition) => _goldminePosition = goldminePosition;

    public void EmptyBag()
    {
        _currentGold = 0;
        _stacker.EmptyStacks();
    } 

    public void WalkToDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goldmine>(out Goldmine goldmine) && _isFarming == false)
        {
            _agent.isStopped = true;
            _isFarming = true;
            StartCoroutine(FarmGold());
        }
    }

    private IEnumerator FarmGold()
    {
        while (_currentGold < _goldCapacity)
        {
            _currentGold++;
            _stacker.StackGold();
            yield return _farmDelay;
        }

        _agent.isStopped = false;
        _isFarming = false;
        WalkToDestination(_basePosition);
    }
}
