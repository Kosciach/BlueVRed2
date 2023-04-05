using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMenuState : EnemyBaseState
{
    public EnemyMenuState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.EnemyStats.ToggleEmitDeath(false);
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
        if (_ctx.EnemySpawner.Switches.MoveToPlayer) StateChange(_factory.MoveToPlayer());
    }
    public override void StateExit()
    {

    }
}
