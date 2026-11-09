using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class attackState : StateBase
{
    public attackState(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName, Rigidbody2D rb) : base(mainControl, stateMachine, StateAnimationBoolName,rb)
    {
    }

    public override void StateBaseUpdate()
    {
        base.StateBaseUpdate();
        attack();
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            stateMachine.changeState(mainControl.nonState);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            stateMachine.changeState(mainControl.moveState);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.changeState(mainControl.jumpState);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.changeState(mainControl.runsState);
        }
        if (!mainControl.isGround)
        {
            stateMachine.changeState(mainControl.fullState);
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
    public void attack()
    {
        if (canATK() && Input.GetKeyDown(KeyCode.J))
        {
            mainControl.timecomput = 0;
            mainControl.atkobj.SetActive(true);
            mainControl.atkobj.SetActive(false);
        }
        if (!canATK() && Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("cd");
        }
    }
    public bool canATK()
    {
        if (mainControl.timecomput >= mainControl.atkCD)
        {
            mainControl.CanAttack = true;
            mainControl.timecomput = math.clamp(mainControl.timecomput, 0, mainControl.atkCD);
        }
        if (mainControl.timecomput < mainControl.atkCD)
        {
            mainControl.timecomput += Time.deltaTime;
            mainControl.CanAttack = false;
        }
        return mainControl.CanAttack;
    }
}
