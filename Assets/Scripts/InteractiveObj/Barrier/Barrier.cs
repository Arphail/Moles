using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _cost;
    [SerializeField] private int _barrierSerialNumber;

    public int SerialNumber => _barrierSerialNumber;

    public float Cost => _cost;

    public void Open() => gameObject.SetActive(false);
}
