using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameOverState : EnemyBaseState
{
    public EnemyGameOverState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.EnemyStats.ToggleEmitDeath(false);
        _ctx.EnemyStats.ToggleEmitDeath(false);
    }
    public override void StateUpdate()
    {
        _ctx.Rotator.RotateToPlayer();
    }
    public override void StateFixedUpdate()
    {
        _ctx.MovementController.MoveGameOver();
    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {

    }
}
