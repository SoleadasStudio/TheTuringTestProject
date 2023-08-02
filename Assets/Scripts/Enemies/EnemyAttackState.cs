using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float distanceToPlayer;
    private float damagePerSecond = 5f;

    private Health playerHealth;

    public EnemyAttackState(AgentsController enemy) : base(enemy)
    {
        playerHealth = enemy.player.GetComponent<Health>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy is starting Attack");
    }

    public override void OnStateUpdate()
    {
        Attack();

        distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);
        if (enemy.player != null)
        {
            if (distanceToPlayer > 2)
            {
                enemy.ChangeStateTo(new EnemyFollowState(enemy));
            }

            enemy.agent.destination = enemy.player.position;

        }
        else
        {
            enemy.ChangeStateTo(new EnemyIdleState(enemy));
        }
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy no longer Attacking");
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(damagePerSecond * Time.deltaTime);
        }
    }
}
