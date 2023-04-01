using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayerState : EnemyBaseState
{
    public EnemyMoveToPlayerState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {

    }
    public override void StateUpdate()
    {
        _ctx.Rotator.RotateToPlayer();
    }
    public override void StateFixedUpdate()
    {
        _ctx.MovementController.MoveToPlayer();
    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {

    }
}
