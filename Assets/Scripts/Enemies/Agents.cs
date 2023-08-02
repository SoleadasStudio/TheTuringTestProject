using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agents : MonoBehaviour
{
    [SerializeField] public Transform[] targetPoints;
    [SerializeField] public Transform agentEye;
    [SerializeField] public float playerCheckDistance;
    [SerializeField] public float checkRadius = .04f;

    private int currentTarget = 0;

    public NavMeshAgent agent;
    public Transform targetPoint;
    public bool isIdle = true;
    public bool isPlayerFound;
    public bool isCloseToPlayer;
    public Transform _player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetPoints[currentTarget].position;
    }

    private void Update()
    {
        if (isIdle)
        {
            Idle();
        }
        else if (isPlayerFound)
        {
            if (isCloseToPlayer)
            {
                AttackPlayer();
            }
            else
            {
                FollowPlayer();
            }
        }
    }

    private void Idle()
    {
        if (agent.remainingDistance < 0.1f)
        {
            currentTarget++;
            if (currentTarget >= targetPoints.Length)
            {
                currentTarget = 0;

            }
            agent.destination = targetPoints[currentTarget].position;
        }

        if (Physics.SphereCast(agentEye.position, checkRadius, transform.forward, out RaycastHit hit, playerCheckDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Player Found!");
                isIdle = false;
                isPlayerFound = true;
                _player = hit.transform;
                agent.destination = _player.position;

            }
        }
    }

    private void FollowPlayer()
    {
        if (_player != null)
        {
            if (Vector3.Distance(transform.position, _player.position) < 2)
            {
                isCloseToPlayer = true;
            }
            else
            {
                isCloseToPlayer = false;
            }
            agent.destination = _player.position;
        }
        else
        {
            isPlayerFound = false;
            isIdle = true;
            isCloseToPlayer = false;
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Player Attacked!");
        if (Vector3.Distance(transform.position, _player.position) > 2)
        {
            isCloseToPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(agentEye.position, checkRadius);
        Gizmos.DrawWireSphere(agentEye.position + agentEye.forward * playerCheckDistance, checkRadius);

        Gizmos.DrawLine(agentEye.position, agentEye.position + agentEye.forward * playerCheckDistance);
    }
    
}
