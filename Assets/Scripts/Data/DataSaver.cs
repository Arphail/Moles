using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class DataSaver : MonoBehaviour
    {
        public readonly List<int> BarrierIds = new List<int>();
        public readonly List<int> GoldmineIds = new List<int>();
        public readonly List<int> GoldmineLevels = new List<int>();

        public void SetBarrier(int id) 
            => BarrierIds.Add(id);

        public void SaveBarrier(int barrierId) 
            => PlayerPrefs.SetInt(Constants.Barrier + BarrierIds[barrierId].ToString(), Constants.PrefsTrue);

        public void SetGoldmine(int id)
        {
            GoldmineIds.Add(id);
            GoldmineLevels.Add(id);
        }

        public void SaveGoldmine(int goldmineId) 
            => PlayerPrefs.SetInt(Constants.Goldmine + GoldmineIds[goldmineId].ToString(), Constants.PrefsTrue);

        public void SaveGoldmineLevel(int goldmineId, int level) 
            => PlayerPrefs.SetInt(GoldmineLevels[goldmineId].ToString(), level);

        public void SaveMoney(float money) 
            => PlayerPrefs.SetFloat(Constants.Money, money);

        public void SaveLevel(string entity, string upgradeType, int level)
        {
            PlayerPrefs.SetInt(entity + upgradeType, level);
            print(PlayerPrefs.GetInt(entity + upgradeType));
        }
    }
}
