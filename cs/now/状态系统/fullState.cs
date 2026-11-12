using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullState : StateBase
{
    public fullState(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName, Rigidbody2D rb) : base(mainControl, stateMachine, StateAnimationBoolName, rb)
    {
    }
    public override void StateBaseUpdate()
    {
        base.StateBaseUpdate();
    }
    public override void EnterState()
    {
        base.EnterState();
        // mainControl.animator.SetBool(StateAnimationBoolName, true);
    }
    public override void ExitState()
    {
        base.ExitState();
        //mainControl.animator.SetBool(StateAnimationBoolName, false);
    }
}
