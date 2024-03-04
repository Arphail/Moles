using TMPro;
using UnityEngine;

public class MoneyStash : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldVisualisation;
    [SerializeField] private DataSaver _saver;
    [SerializeField] private float _money;

    public float Money => _money;

    private void Update()
    {
        _goldVisualisation.text = _money.ToString();
    }

    public void AddGold(float goldAmount)
    {
        _money += goldAmount;
        _saver.SaveMoney(_money);
    }

    public void SpendGold(float goldAmound)
    {
        _money -= goldAmound;
        _saver.SaveMoney(_money);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoldFarmer farmer))
        {
            AddGold(farmer.CurrentGold);
            farmer.EmptyBag();
        }
    }
}
