using UnityEngine;

public class TreasureAnimationHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _treasureAppearEffect;
    [SerializeField] private ParticleSystem _treasureOpenEffect;
    [SerializeField] private Animator _animator;

    public void PlayAnimation() => _animator.SetTrigger(Constants.AnimationTrigger);
    public void PlayAppearEffect() => _treasureAppearEffect.Play();
    public void PlayOpenEffect() => _treasureOpenEffect.Play();
}
