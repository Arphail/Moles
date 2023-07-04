using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DataSaver))]
public class DataLoader : MonoBehaviour
{
    [SerializeField] private List<Barrier> _barriersToOpen;

    private DataSaver _saver;

    private void Awake()
    {
        _saver = GetComponent<DataSaver>();
    }

    private void Start()
    {
        for(int i = 0; i < _barriersToOpen.Count; i++)
        {
            _saver.SetBarrier(_barriersToOpen[i].SerialNumber);

            if (PlayerPrefs.HasKey(Constants.Barrier + _saver.BarrierNumbers[i].ToString()))
                if (PlayerPrefs.GetInt(Constants.Barrier + _saver.BarrierNumbers[i].ToString()) == 1)
                    _barriersToOpen[i].Open();
        }
    }
}
