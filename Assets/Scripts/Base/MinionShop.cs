using UnityEngine;

public class MinionShop : MonoBehaviour
{
    [SerializeField] private MinionSpawner _spawner;
    [SerializeField] private Base _base;
    [SerializeField] private Minion _basicMinionTemplate;
    [SerializeField] private int _basicMinionCost;
    [SerializeField] private Minion _fastMinionTemplate;
    [SerializeField] private int _fastMinionCost;
    [SerializeField] private Minion _bruiserMinionTemplate;
    [SerializeField] private int _bruiserMinionCost;

    public void BuyBasicMinion()
    {
        if (_base.Gold >= _basicMinionCost && _spawner.CanSpawn)
        {
            _spawner.SpawnMinion(_basicMinionTemplate);
            _base.SpendGold(_basicMinionCost);
        }
    } 

    public void BuyFastMinion()
    {
        if (_base.Gold >= _fastMinionCost && _spawner.CanSpawn)
        {
            _spawner.SpawnMinion(_fastMinionTemplate);
            _base.SpendGold(_fastMinionCost);
        }
    }

    public void BuyBruiserMinion()
    {
        if (_base.Gold >= _bruiserMinionCost && _spawner.CanSpawn)
        {
            _spawner.SpawnMinion(_bruiserMinionTemplate);
            _base.SpendGold(_bruiserMinionCost);
        }
    }
}
