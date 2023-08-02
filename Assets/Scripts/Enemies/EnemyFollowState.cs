using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyState
{
    private float distancetoPlayer;

    public EnemyFollowState(AgentsController enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Enemy will follow now");
    }

    public override void OnStateUpdate()
    {
        if (enemy.player != null)
        {
            distancetoPlayer = Vector3.Distance(enemy.transform.position, enemy.player.position);
            if (distancetoPlayer > 10)
            {
                enemy.ChangeStateTo(new EnemyIdleState(enemy));
            }
            if (distancetoPlayer < 2)
            {
                enemy.ChangeStateTo(new EnemyAttackState(enemy));
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
        Debug.Log("Enemy will NOT follow now");
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
