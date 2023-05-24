using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkinTreasure : Treasure
{
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
        print("OMG U GOT A SKIN!!!");
    }

    public override void SetPosition(Transform transform) => gameObject.transform.position = transform.position;
}
