using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    protected EnemyStateMachine _ctx;
    protected EnemyStateFactory _factory;

    public EnemyBaseState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName)
    {
        _ctx = ctx;
        _factory = factory;
        ctx.CurrentStateName = stateName;
    }


    public abstract void StateEnter();
    public abstract void StateUpdate();
    public abstract void StateFixedUpdate();
    public abstract void StateCheckChange();
    public abstract void StateExit();


    protected void StateChange(EnemyBaseState newState)
    {
        StateExit();
        _ctx.CurrentState = newState;
        _ctx.CurrentState.StateEnter();
    }
}
