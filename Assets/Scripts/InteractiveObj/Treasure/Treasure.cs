using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Treasure : MonoBehaviour
{
    [SerializeField] private GameObject _mesh;
    [SerializeField] private TreasureAnimationHandler _animationHandler;
    [SerializeField] private SoundHandler _sound;
    [SerializeField] private int _delaySeconds;

    public event UnityAction<Treasure> PickedUp;

    private WaitForSeconds _delay;
    private Coroutine _openChestWithDelay;

    private void OnEnable()
    {
        _delay = new WaitForSeconds(_delaySeconds);
        _mesh.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && _openChestWithDelay == null)
        {
            _mesh.gameObject.SetActive(true);
            _sound.PlaySound();
            _openChestWithDelay = StartCoroutine(OpenChestWithDelay());
        }
    }

    private IEnumerator OpenChestWithDelay()
    {
        _animationHandler.PlayAppearEffect();
        yield return _delay;
        _animationHandler.PlayAnimation();
        _animationHandler.PlayOpenEffect();
        yield return _delay;
        PickedUp?.Invoke(this);
        _openChestWithDelay = null;
        gameObject.SetActive(false);
    }
}
