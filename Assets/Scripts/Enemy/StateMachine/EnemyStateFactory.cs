using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFactory
{
    private EnemyStateMachine _stateMachine;

    public EnemyStateFactory(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }




    public EnemyBaseState MoveToPlayer()
    {
        return new EnemyMoveToPlayerState(_stateMachine, this, "MoveToPlayer");
    }
    public EnemyBaseState Menu()
    {
        return new EnemyMenuState(_stateMachine, this, "Menu");
    }
    public EnemyBaseState GameOver()
    {
        return new EnemyGameOverState(_stateMachine, this, "GameOver");
    }
}
