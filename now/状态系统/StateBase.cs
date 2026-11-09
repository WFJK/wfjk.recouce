using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public  class StateBase
{
    public StateMachine stateMachine;
    public string StateAnimationBoolName;
    public Rigidbody2D rb;
    public mainControl mainControl;

    public StateBase(mainControl mainControl, StateMachine stateMachine, string StateAnimationBoolName,Rigidbody2D rb) 
    {
        this.mainControl = mainControl;
        this.stateMachine = stateMachine;
        this.StateAnimationBoolName = StateAnimationBoolName;
        this.rb = rb;
    }


    public virtual void ExitState(){ }
    public virtual void EnterState(){ }
    public virtual void StateBaseUpdate(){ }
    public void stateCondition()
    {
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            stateMachine.changeState(mainControl.atksState);
        }
        if (!mainControl.isGround)
        {
            stateMachine.changeState(mainControl.fullState);
        }
    }
}
