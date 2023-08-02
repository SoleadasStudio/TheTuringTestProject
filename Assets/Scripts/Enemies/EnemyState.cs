using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected AgentsController enemy;
    public EnemyState(AgentsController enemy)
    {
        this.enemy = enemy;
    }

    public abstract void OnStateEnter();

    public abstract void OnStateUpdate();

    public abstract void OnStateExit();

}
