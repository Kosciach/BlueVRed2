using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.ShootingScript.enabled = true;
        _ctx.ShootingScript.ToggleShootingFromInput(false);
        _ctx.PlayerStats.ToggleCorruption(false);
        _ctx.AbilityController.enabled = false;
    }
    public override void StateUpdate()
    {

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
