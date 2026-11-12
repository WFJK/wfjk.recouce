using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runsState : StateBase
{
    public runsState(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName, Rigidbody2D rb) : base(mainControl, stateMachine, StateAnimationBoolName, rb)
    {
    }

    public override void StateBaseUpdate()
    {
        base.StateBaseUpdate();
        Run();
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
    public void Run()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            rb.velocity = new Vector2(movement.x * mainControl.runSpeed, rb.velocity.y);
        }
    }
}
