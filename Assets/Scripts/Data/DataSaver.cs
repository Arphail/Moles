using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public readonly List<int> BarrierNumbers = new List<int>();
    public readonly List<int> GoldmineNumbers = new List<int>();
    public readonly List<int> GoldmineLevels = new List<int>();

    public void SetBarrier(int number) => BarrierNumbers.Add(number);

    public void SaveBarrier(int barrierNumber) => PlayerPrefs.SetInt(Constants.Barrier + BarrierNumbers[barrierNumber].ToString(), 1);

    public void SetGoldmine(int number)
    {
        GoldmineNumbers.Add(number);
        GoldmineLevels.Add(number);
    }

    public void SaveGoldmine(int goldmineNumber) => PlayerPrefs.SetInt(Constants.Goldmine + GoldmineNumbers[goldmineNumber].ToString(), 1);

    public void SaveGoldmineLevel(int goldmineNumber, int level) => PlayerPrefs.SetInt(GoldmineLevels[goldmineNumber].ToString(), level);

    public void SaveMoney(float money) => PlayerPrefs.SetFloat(Constants.Money, money);

    public void SaveLevel(string entity, string upgradeType, int level)
    {
        PlayerPrefs.SetInt(entity + upgradeType, level);
        print(PlayerPrefs.GetInt(entity + upgradeType));
    }
}
