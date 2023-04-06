using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
    private PlayerStateMachine _stateMachine;

    public PlayerStateFactory(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }




    public PlayerBaseState MoveShoot()
    {
        return new PlayerMoveShootState(_stateMachine, this, "MoveShoot");
    }
    public PlayerBaseState Turret()
    {
        return new PlayerTurretState(_stateMachine, this, "Turret");
    }
    public PlayerBaseState Death()
    {
        return new PlayerDeathState(_stateMachine, this, "Death");
    }
}
