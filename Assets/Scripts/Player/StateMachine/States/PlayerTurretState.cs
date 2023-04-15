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
        _ctx.PlayerStats.ToggleCorruption(false);
        _ctx.PlayerStats.ResetCorruption();
        _ctx.AbilityController.enabled = false;
    }
    public override void StateUpdate()
    {
        float distanceToEnemy = _ctx.AimingController.TurretRotation();
        _ctx.ShootingScript.TurretShooting(distanceToEnemy);
    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {
        if (_ctx.Switches.MoveShoot) StateChange(_factory.MoveShoot());
    }
    public override void StateExit()
    {
        _ctx.Switches.Turret = false;
    }
}
