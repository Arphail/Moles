using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GoldmineUpgrader))]
public class Goldmine : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private GoldmineUpgradeUi _ui;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GoldmineUpgradeAnimationHandler _animationHandler;
    [SerializeField] private GameObject _level0Model;
    [SerializeField] private SoundHandler _soundHandler;
 
    public event UnityAction<Goldmine> Activated;

    public event UnityAction<Goldmine> Upgraded;

    private GoldmineUpgrader _upgrader;

    public bool IsActivated { get; private set; }

    private void Start()
    {
        _level0Model.SetActive(false);
        _particleSystem.Stop();
        _upgrader = GetComponent<GoldmineUpgrader>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
        {
            if (IsActivated == false)
            {
                _level0Model.SetActive(true);
                _particleSystem.Play();
                Activated?.Invoke(this);
                IsActivated = true;
            }

            if(_upgrader.CurrentLevel < _upgrader.MaxLevel)
            {
                _ui.gameObject.SetActive(true);
                _ui.Button.onClick.AddListener(UpgradeGoldmine);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<GoldFarmer>(out GoldFarmer farmer))
            farmer.StartFarm();

        if(other.TryGetComponent<Upgrader>(out Upgrader upgrader) && _ui.isActiveAndEnabled == true)
            _ui.ShowStats(_upgrader.CurrentLevel, _upgrader.MaxLevel, _upgrader.CurrentLevelCost);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<GoldFarmer>(out GoldFarmer farmer))
            farmer.StopFarm();

        if (other.TryGetComponent<Upgrader>(out Upgrader upgrader))
        {
            _ui.Button.onClick.RemoveListener(UpgradeGoldmine);
            _ui.gameObject.SetActive(false);
        }
    }

    public void UpgradeGoldmine()
    {
        if (_upgrader.CurrentLevel < _upgrader.MaxLevel && _base.Gold >= _upgrader.CurrentLevelCost)
        {
            _base.SpendGold(_upgrader.CurrentLevelCost);
            _soundHandler.PlaySound();
            _animationHandler.ChangeModel();
            _upgrader.UpgradeGoldmineMinionLimit();
            Upgraded?.Invoke(this);
        }
    }
}
