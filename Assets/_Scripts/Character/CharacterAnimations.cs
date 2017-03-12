using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private TestAnimationStateMachineBehaviour _testAnimationStateMachine;

    void OnEnable()
    {
        _testAnimationStateMachine = _animator.GetBehaviour<TestAnimationStateMachineBehaviour>();
    }

    void OnDisable()
    {
        _testAnimationStateMachine.AnimationExited -= OnTestAnimationExited;
    }

	public void StartIdleAnimation()
    {
        _animator.SetTrigger("idle");
    }

    private System.Action _testAnimationCallBack;

    public void StartTestAnimations(System.Action callback)
    {
        _testAnimationCallBack = callback;

        _testAnimationStateMachine.AnimationExited += OnTestAnimationExited;    // чтобы вызвать колбэк подписываемя на нужное событие "стэйт машины" аниматора

        _animator.SetTrigger("animation");
    }

    public void RestartAnimations()
    {
        _animator.SetTrigger("reset");
    }

    private void OnTestAnimationExited()
    {
        _testAnimationStateMachine.AnimationExited -= OnTestAnimationExited;

        if (_testAnimationCallBack != null)
        {
            _testAnimationCallBack();
            _testAnimationCallBack = null;
        }
    }
}
