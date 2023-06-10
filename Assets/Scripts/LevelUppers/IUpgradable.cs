using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    public abstract void UpgradeMoveSpeed();
    public abstract void UpgradeGoldCapacity();
    public abstract void UpgradeFarmDelay();
}
