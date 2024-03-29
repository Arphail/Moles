using System;
using System.Collections;
using UnityEngine;

namespace InteractiveObj.Treasure
{
    public class Treasure : MonoBehaviour
    {
        [SerializeField] private GameObject _mesh;
        [SerializeField] private TreasureAnimationHandler _animationHandler;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private int _delaySeconds;

        private WaitForSeconds _delay;
        private Coroutine _openChestWithDelay;

        public event Action<Treasure> PickedUp;

        private void OnEnable()
        {
            _delay = new WaitForSeconds(_delaySeconds);
            _mesh.gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player.Player>(out Player.Player player) && _openChestWithDelay == null)
            {
                _mesh.gameObject.SetActive(true);
                _sound.Play();
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
}
