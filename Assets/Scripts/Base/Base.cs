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
        if (other.TryGetComponent(out GoldFarmer farmer))
        {
            _gold += farmer.CurrentGold;
            farmer.EmptyBag();
        }
    }

    public void AddGold(float goldAmount) => _gold += goldAmount;

    public void SpendGold(float goldAmound) => _gold -= goldAmound;
}
