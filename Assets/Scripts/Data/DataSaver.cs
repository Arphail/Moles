using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public readonly List<int> BarrierNumbers = new List<int>();
    
    public void SaveBarrier(int barrierNumber) => PlayerPrefs.SetInt(Constants.Barrier + BarrierNumbers[barrierNumber].ToString(), 1);

    public void SetBarrier(int number) => BarrierNumbers.Add(number);
}
