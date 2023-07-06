using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    public abstract void BuyMoveSpeedUpgrade();
    public abstract void BuyCapacityUpgrade();
    public abstract void BuyDelayUpgrade();
}
