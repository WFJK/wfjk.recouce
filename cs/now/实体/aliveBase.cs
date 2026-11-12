using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class aliveBase : MonoBehaviour, needTakeDamage
{


    public string ID;
    [Header("script")]
    public StateMachine stateMachine;
    public StateBase stateBase;
    [Header("commponent")]
    public Rigidbody2D rb;
    public Animator animator;
    [Header("groundDetect")]
    public Vector2 detectPoint;
    public float detectRange;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Collider2D[] collider2Ds;

    private void Awake()
    {
        stateMachine=new StateMachine();
    }

    public virtual void Start()// 初始化玩家生命值
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawRay(detectPoint, Vector2.right);
    }
    public  virtual bool isdetected() 
    {
        if (Physics2D.Raycast(detectPoint, Vector2.right))
        {
            return true;
        
        }
        return false;
    }
    public virtual Transform detectPosition()
    {
        collider2Ds = Physics2D.OverlapCircleAll(detectPoint, detectRange);



        return null;
    }

}