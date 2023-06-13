using UnityEngine;

public class GoldmineUpgradeAnimationHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _models;

    private GameObject _currentModel;

    private void Start()
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

        _currentModel.SetActive(true);
    }
}
