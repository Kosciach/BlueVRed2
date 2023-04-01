using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretState : PlayerBaseState
{
    public PlayerTurretState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.ShootingScript.enabled = true;
        _ctx.ShootingScript.ToggleShootingFromInput(false);
    }
    public override void StateUpdate()
    {
        _ctx.ShootingScript.TurretShooting();
        _ctx.AimingController.TurretRotation();
    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {

    }
}
