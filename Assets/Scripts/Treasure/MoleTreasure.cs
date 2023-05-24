using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoleTreasure : Treasure
{
    [SerializeField] private MinionSpawner _spawner;
    [SerializeField] private Minion _minion;

    public override event UnityAction Accquired;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            AccquireTreasure();
            gameObject.SetActive(false);
        }
    }

    public override void AccquireTreasure()
    {
        Accquired?.Invoke();
        _spawner.SpawnMinion(_minion);
    }

    public override void SetPosition(Transform transform) => gameObject.transform.position = transform.position;
}
