using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GoldFarmer))]
public class Minion : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GoldFarmer _farmer;

    private Vector3 _basePosition;
    private Vector3 _goldminePosition;

    public Vector3 GoldminePosition => _goldminePosition;

    public bool IsStopped => _agent.isStopped;

    private void Update()
    {
        if (_farmer.CurrentGold < _farmer.GoldCapacity)
            WalkToDestination(_goldminePosition);

        else if (_farmer.CurrentGold == _farmer.GoldCapacity)
        {
            WalkToDestination(_basePosition);
            _agent.isStopped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goldmine>(out Goldmine goldmine))
            _agent.isStopped = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Goldmine>(out Goldmine goldmine))
            _agent.isStopped = false;
    }

    public void UpgradeMovementSpeed(int speedUpgrade) => _agent.speed += speedUpgrade;

    public void UpgradeCapacity() => _farmer.UpgradeGoldCapacity();

    public void UpgradeDelay() => _farmer.UpgradeFarmDelay();

    public void SetBase(Vector3 basePosition) => _basePosition = basePosition;

    public void SetGoldmine(Vector3 goldminePosition) => _goldminePosition = goldminePosition;

    private void WalkToDestination(Vector3 destination) => _agent.SetDestination(destination);
}
