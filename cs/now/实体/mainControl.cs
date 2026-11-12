using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;



[Serializable]
public class mainControl : aliveBase   
{
    [Header("状态实例")]

    public nonState nonState;
    public moveState moveState;
    public jumpState jumpState;
    public fullState fullState;
    public attackState atksState;
    public runsState runsState;
    public string StateAnimationBoolName;

    [Header("生成物")]
    public GameObject atkobj;
    [Header("状态")]
    public bool isGround;
    [Header("run")]
    public float runSpeed;
    [Header("atk")]
    public bool CanAttack = true;
    public bool isAttacking = false;
    public double atkCD = 0.5;
    public double timecomput;
    public float attackRange = 1;
    public float knockbackForce = 1;
    public float attackDamage = 1;
    [Header("jump")]
    public float jumph;
    public int crtjumpcount;
    public int maxjumpcount = 2;
    [Header("move")]
    public float moveSpeed;

    [Header("groundDetect")]
    public Vector3 GizmosChange;
    public float groundDetectLong=1;
    public LayerMask layerMask;


    public Collider2D[] collider2d;




    private void Awake()
    {
        stateMachine = new StateMachine();
        stateBase = new StateBase(this, stateMachine, StateAnimationBoolName,rb);
        nonState = new nonState(this, stateMachine, StateAnimationBoolName,rb);
        moveState = new moveState(this, stateMachine, StateAnimationBoolName,rb);
        jumpState =new jumpState(this, stateMachine, StateAnimationBoolName,rb);
        atksState=new attackState(this, stateMachine, StateAnimationBoolName,rb);
        runsState=new runsState(this, stateMachine, StateAnimationBoolName,rb);

    }
    public override void Start()
    {
        base.Start();
        stateMachine.giveBasestate(nonState);

    }
    void Update()
    {
        stateMachine.StateMachineUpdate();
        isOnGround();
    }
    public override void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * groundDetectLong);
    }
    public bool groundRaycastResult() 
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, groundDetectLong, layerMask))
        {
            return true;
        }
        return false;
    }
    public void isOnGround() 
    {
        isGround = groundRaycastResult();
    }






}












