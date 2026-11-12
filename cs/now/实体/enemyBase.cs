using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
public class enemyBase : aliveBase
{
    [Header("MonsterUI")]
    public Text enemyName;
    public Image MonsterImage;


    [Header("reward")]
    public int expReward = 10;

    [Header("state")]

    public nonState nonState;
    public moveState PatrolState;
    public jumpState jumpState;
    public fullState fullState;
    public attackState AttackState;
    public runsState ChasingState;
    public bool isChasing;
    public bool isPatrolling;
    public bool isAttacking;

    [Header("attack")]
    public float attackCooldown;
    public float lastAttackTime;

    [Header("MonsterAI")]
    public float detectionRange = 8f;      // 发现玩家的距离
    public float attackRange = 2f;         // 攻击距离
    public float patrolRadius = 5f;        // 巡逻半径
    public float patrolWaitTime = 2f;      // 巡逻等待时间
    public float chaseSpeed = 4f;          // 追击速度
    public float patrolSpeed = 2f;         // 巡逻速度
    private Vector2 patrolCenter;           // 巡逻中心点
    private Vector2 patrolDestination;      // 巡逻目标点

    [Header("conponent")]
    private Vector3 playerPosition;              // 玩家目标
    private SpriteRenderer spriteRenderer;  // 精灵渲染器
    private UnityEngine.AI.NavMeshAgent navAgent; // 导航网格代理，


    //在 Inspector 中Navigation Static（勾选），打开导航窗口切换到Bake标签页，点击Bake按钮（场景中会显示蓝色区域（可行走的 NavMesh）。
    private void Awake()
    {
        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (navAgent != null)
        {
            navAgent.updateRotation = false; // 2D游戏不需要旋转
            navAgent.updateUpAxis = false;
        }
    }
    public override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        enemyAI();
    }

    public void enemyAI()
    {
        if (playerPosition == null) 
        { 
            FindPlayerTarget(); 
        }

        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition);
        if (distanceToPlayer <= attackRange)
        {
            // 在攻击范围内，执行攻击
            ChaseAndAttack(true);
        }
        else if (distanceToPlayer <= detectionRange)
        {
            // 在发现范围内，追击玩家
            ChaseAndAttack(false);
        }
        else
        {
            // 超出发现范围，返回巡逻
            ReturnToPatrol();
        }

    }

    private void FindPlayerTarget()// 查找玩家目标
    {
        // 通过GameManager获取玩家位置
        if (playerPosition == null)
        {
            return;
        }
        playerPosition = GetComponent<mainControl>().transform.position;
    }

    private void ChaseAndAttack(bool shouldAttack)// 追击或攻击玩家
    {
        // 停止巡逻
        isPatrolling = false;

        if (shouldAttack)
        {
            // 面向玩家
            FaceTarget(playerPosition);

            // 检查攻击冷却
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // 执行攻击
                PerformAttack();
                lastAttackTime = Time.time;
            }

            // 停止移动
            StopMovement();
            isChasing = false;
            isAttacking = true;
        }
        else
        {
            // 追击玩家
            isChasing = true;
            isAttacking = false;
            ChasePlayer();
        }
    }
    private void ChasePlayer()// 追击玩家
    {
        if (playerPosition == null) return;

        // 面向玩家
        FaceTarget(playerPosition);

        // 使用NavMeshAgent或刚体移动
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            navAgent.speed = chaseSpeed;
            navAgent.SetDestination(playerPosition);//.SetDestination是navAgent方法
        }
        else
        {
            // 使用刚体移动
            Vector2 direction = (playerPosition - transform.position).normalized;
            rb.velocity = direction * chaseSpeed;
        }
    }
    private void ReturnToPatrol()// 返回巡逻状态
    {
        // 停止追击
        isChasing = false;
        isAttacking = false;

        // 如果有NavMeshAgent，停止导航
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            navAgent.ResetPath();
        }

        // 停止移动
        StopMovement();

        // 如果不在巡逻，开始巡逻
        if (!isPatrolling)
        {
            isPatrolling = true;
        }

        // 巡逻移动
        PatrolMove();
    }
    private void PatrolMove()// 巡逻移动
    {
        // 计算到巡逻目标点的距离
        float distanceToDestination = Vector2.Distance(transform.position, patrolDestination);

        if (distanceToDestination < 0.1f)
        {
            // 到达目标点，设置新的目标点
            StartCoroutine(WaitAndSetNewPatrolDestination());
            return;
        }

        // 面向巡逻目标点
        FaceTarget(patrolDestination);

        // 移动向巡逻目标点
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            navAgent.speed = patrolSpeed;
            navAgent.SetDestination(patrolDestination);
        }
        else
        {
            Vector2 direction = (patrolDestination - (Vector2)transform.position).normalized;
            rb.velocity = direction * patrolSpeed;
        }
    }
    private IEnumerator WaitAndSetNewPatrolDestination()// 协程：等待后设置新的巡逻目标点
    {
        isPatrolling = false;
        StopMovement();

        // 等待一段时间
        yield return new WaitForSeconds(patrolWaitTime);

        // 设置新的巡逻目标点
        SetNewPatrolDestination();
        isPatrolling = true;
    }
    private void SetNewPatrolDestination()// 设置新的巡逻目标点
    {
        // 在巡逻半径内随机选择一个点
        Vector2 randomOffset = Random.insideUnitCircle * patrolRadius;
        patrolDestination = patrolCenter + randomOffset;

        // 确保目标点在NavMesh上（如果使用）
        if (navAgent != null && navAgent.isOnNavMesh)
        {
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(patrolDestination, out hit, patrolRadius, UnityEngine.AI.NavMesh.AllAreas))
            {
                patrolDestination = hit.position;
            }
        }
    }
    private void FaceTarget(Vector3 targetPosition)// 面向目标位置
    {
        Vector2 direction = targetPosition - transform.position;
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        else if (direction.x < 0)
            spriteRenderer.flipX = true;
    }
    private void StopMovement()// 停止移动
    {
        rb.velocity = Vector2.zero;

        if (navAgent != null && navAgent.isOnNavMesh)
        {
            navAgent.velocity = Vector3.zero;
            navAgent.ResetPath();
        }
    }
    private void PerformAttack()// 执行攻击
    {
        isAttacking = true;
        Invoke(nameof(ResetAttack), 0.5f);// 重置攻击状态
    }
    private void ResetAttack()// 重置攻击状态
    {
        isAttacking = false;
    }

}
