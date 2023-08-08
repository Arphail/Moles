using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldVisualisation;
    [SerializeField] private DataSaver _saver;
    [SerializeField] private float _money;

    public float Money => _money;

    private void Update()
    {
        _goldVisualisation.text = _money.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoldFarmer farmer))
        {
            AddGold(farmer.CurrentGold);
            farmer.EmptyBag();
        }
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
}
