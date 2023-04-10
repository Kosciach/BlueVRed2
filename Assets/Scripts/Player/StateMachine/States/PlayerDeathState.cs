using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private float _waitingTime = 1.5f;
    private int _timerControll = 0;
    private float _timer = 1.5f;
    private bool _exploded = false;
    public PlayerDeathState(PlayerStateMachine ctx, PlayerStateFactory factory, string stateName) :base(ctx, factory, stateName) { }


    public override void StateEnter()
    {
        _ctx.Collider.enabled = false;
        _ctx.ShootingScript.ToggleShootingFromInput(false);
        _ctx.PlayerStats.ToggleCorruption(false);
        _ctx.AbilityController.enabled = false;
        _ctx.Rigidbody.velocity = Vector3.zero;

        StartPlayerExplosion();
    }
    public override void StateUpdate()
    {
        _timer -= _timerControll * Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0, _waitingTime);

        Debug.Log(_timer);

        if (_timer == 0 && !_exploded) Explode();
    }
    public override void StateFixedUpdate()
    {

    }
    public override void StateCheckChange()
    {

    }
    public override void StateExit()
    {
        _ctx.Switches.Death = false;
    }


    private void StartPlayerExplosion()
    {
        ShakeScript.Instance.Shake(5, 0);
        _ctx.transform.LeanScale(Vector3.zero, 2).setOnComplete(() =>
        {
            ShakeScript.Instance.Shake(0, 5);
            _timerControll = 1;
        });
    }
    private void Explode()
    {
        _exploded = true;
        GameObject.Instantiate(_ctx.PlayerDeathCircle, _ctx.transform.position, Quaternion.identity);
    }
}
