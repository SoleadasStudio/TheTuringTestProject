using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentsController : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Transform targetPoint;   

    [SerializeField] public Transform[] targetPoints;
    [SerializeField] public Transform agentEye;

    [SerializeField] public float playerCheckDistance;
    [SerializeField] public float checkRadius = .04f;

    private EnemyState currentState;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        currentState = new EnemyIdleState(this);
        currentState.OnStateEnter();
    }

    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeStateTo(EnemyState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }
}
