using UnityEngine;

public class GoldmineModelChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _models;
    [SerializeField] private ParticleSystem[] _effects;

    private GameObject _currentModel;

    private void Awake()
    {
        _currentModel = _models[0];
    }

    public void ChangeModel()
    {
        _currentModel.SetActive(false);

        for (int i = 0; i < _models.Length; i++)
        {
            if (_models[i] == _currentModel)
            {
                _currentModel = _models[i + 1];
                break;
            }
        }

        foreach (var effect in _effects)
            effect.Play();

        _currentModel.SetActive(true);
    }
}
