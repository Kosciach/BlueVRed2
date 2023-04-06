using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayerState : EnemyBaseState
{
    public EnemyMoveToPlayerState(EnemyStateMachine ctx, EnemyStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.EnemyStats.ToggleEmitDeath(true);
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
        if (_ctx.EnemySpawner.Switches.GameOver) StateChange(_factory.GameOver());
        else if(_ctx.EnemySpawner.Switches.Menu) StateChange(_factory.Menu());
    }
    public override void StateExit()
    {

    }
}
