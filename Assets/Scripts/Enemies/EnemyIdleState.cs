using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private int currentTarget = 0;
    public EnemyIdleState(AgentsController enemy) : base(enemy)
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }
    public override void OnStateEnter()
    {
        enemy.agent.destination = enemy.targetPoints[currentTarget].position;
        Debug.Log("Enter IDLING");    }

    public override void OnStateExit()
    {
        Debug.Log(" Exit Idling");
    }

    public override void OnStateUpdate()
    {
        if (enemy.agent.remainingDistance < 0.1f)
        {
            currentTarget++;
            if (currentTarget >= enemy.targetPoints.Length)
            {
                currentTarget = 0;
            }
            enemy.agent.destination = enemy.targetPoints[currentTarget].position;
        }

        if (Physics.SphereCast(enemy.agentEye.position, enemy.checkRadius, enemy.transform.forward, out RaycastHit hit, enemy.playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found!!!!");

                enemy.player = hit.transform;
                enemy.agent.destination = enemy.player.position;

                enemy.ChangeStateTo(new EnemyFollowState(enemy));


            }
        }

    }
}
