using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private float _cost;

    public float Cost => _cost;

    public void Open() => gameObject.SetActive(false);
}
