using UnityEngine;

public class TestAnimationStateMachineBehaviour : StateMachineBehaviour
{
    public event System.Action AnimationExited;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (AnimationExited != null)
            AnimationExited();
    }
}
