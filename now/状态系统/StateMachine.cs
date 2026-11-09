using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public StateBase CurrentState { get; private set; }

    public void giveBasestate(StateBase stateBase)
    {
        CurrentState = stateBase;
    }

    public void changeState(StateBase newState)    // 切换状态
    {
        // 防止重复切换同一状态
        if (CurrentState == newState) return;

        // 退出当前状态
        CurrentState.ExitState();

        // 切换
        CurrentState = newState;

        // 进入新状态
        CurrentState.EnterState();
    }
    public void StateMachineUpdate()
    {
        CurrentState.StateBaseUpdate();
    }





}
