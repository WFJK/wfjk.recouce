using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpState : StateBase
{
    public jumpState(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName, Rigidbody2D rb) : base(mainControl, stateMachine, StateAnimationBoolName, rb)
    {
    }

    public override void StateBaseUpdate()
    {
        base.StateBaseUpdate();
        Jump();
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
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && mainControl.isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, mainControl.jumph);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !mainControl.isGround && mainControl.crtjumpcount > 1)
        {
            mainControl.crtjumpcount -= 1;
            rb.velocity = new Vector2(rb.velocity.x, mainControl.jumph);
        }
        if (mainControl.isGround) { mainControl.crtjumpcount = mainControl.maxjumpcount; }
    }
}
