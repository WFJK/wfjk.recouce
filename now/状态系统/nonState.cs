using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class nonState : jumpState
{
    public nonState(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName, Rigidbody2D rb) : base(mainControl, stateMachine, StateAnimationBoolName, rb)
    {
    }
    public override void StateBaseUpdate()
    {
        base.StateBaseUpdate();

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            stateMachine.changeState(mainControl.moveState);
        }
    }
    public override void EnterState()
    {
        base.EnterState();
        //mainControl.animator.SetBool(StateAnimationBoolName, true);
    }
    public override void ExitState()
    {
        base.ExitState();
        //mainControl.animator.SetBool(StateAnimationBoolName, false);
    }
}






