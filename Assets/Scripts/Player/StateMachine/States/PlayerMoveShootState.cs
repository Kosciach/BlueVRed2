using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveShootState : PlayerBaseState
{
    public PlayerMoveShootState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.ShootingScript.enabled = true;
        _ctx.ShootingScript.ToggleShootingFromInput(true);
    }
    public override void StateUpdate()
    {
        _ctx.AimingController.RotateToMouse();
    }
    public override void StateFixedUpdate()
    {
        _ctx.MovementController.MovePlayer();
    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {

    }
}
