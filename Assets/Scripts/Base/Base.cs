using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldVisualisation;
    [SerializeField] private float _gold;

    public float Gold => _gold;

    private void Update()
    {
        _goldVisualisation.text = _gold.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Minion minion))
        {
            _gold += minion.CurrentGold;
            minion.EmptyBag();
            minion.WalkToDestination(minion.GoldminePosition);
        }
    }

    public void AddGold(float goldAmount) => _gold += goldAmount;

    public void SpendGold(float goldAmound) => _gold -= goldAmound;
}
