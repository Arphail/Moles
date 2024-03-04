using System.Collections.Generic;
using UnityEngine;

public class GoldStacker : MonoBehaviour
{
    [SerializeField] private GoldChunk _goldChunkTemplate;
    [SerializeField] private Transform _head;
    [SerializeField] private float _stackingGap;
    [SerializeField] private AudioSource _soundHandler;

    private List<GoldChunk> _chunks;
    private float _currentStackGap = 0;

    private void OnEnable()
    {
        _chunks = new List<GoldChunk>();
    }

    public void StackGold()
    {
        GoldChunk gold = Instantiate(_goldChunkTemplate, _head.position, Quaternion.identity);
        _soundHandler.Play();
        gold.transform.SetParent(_head, true);
        gold.transform.localPosition = new Vector3(0, _currentStackGap, 0);
        _chunks.Add(gold);
        _currentStackGap += _stackingGap;
    }

    public void EmptyStacks()
    {
        foreach (var gold in _chunks)
        {
            gold.gameObject.SetActive(false);
            _currentStackGap = 0;
        }
    }
}
