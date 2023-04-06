using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private PlayerBaseState _currentState; public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    private PlayerStateFactory _factory;
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }

    [Space(20)]
    [Header("====PlayerScripts====")]
    [SerializeField] InputController _inputController; public InputController InputController { get { return _inputController; } }
    [SerializeField] MovementController _movementController; public MovementController MovementController { get { return _movementController; } }
    [SerializeField] AimingController _aimingController; public AimingController AimingController { get { return _aimingController; } }
    [SerializeField] ShootingScript _shootingScript; public ShootingScript ShootingScript { get { return _shootingScript; } }
    [SerializeField] PlayerStats _playerStats; public PlayerStats PlayerStats { get { return _playerStats; } }
    [SerializeField] AbilitiesScript _abilityController; public AbilitiesScript AbilityController { get { return _abilityController; } }


    [Space(20)]
    [Header("====Switches====")]
    [SerializeField] SwitchesClass _switches; public SwitchesClass Switches { get { return _switches; } set { _switches = value; } }



    [System.Serializable]
    public class SwitchesClass
    {
        public bool Turret;
        public bool MoveShoot;
        public bool Death;
    }



    private void Awake()
    {
        _factory = new PlayerStateFactory(this);
        _currentState = _factory.Turret();
        _currentState.StateEnter();
    }

    private void Update()
    {
        _currentState.StateUpdate();
        _currentState.StateCheckChange();
    }
    private void FixedUpdate()
    {
        _currentState.StateFixedUpdate();
    }



    public void SwitchToMoveShoot()
    {
        _switches.MoveShoot = true;
    }
    public void SwitchToTurret()
    {
        _switches.Turret = true;
    }
    public void SwitchToDeath()
    {
        _switches.Death = true;
    }


    public void OnEnable()
    {
        PlayerStats.Corrupted += SwitchToDeath;
    }
    public void OnDisable()
    {
        PlayerStats.Corrupted -= SwitchToDeath;
    }
}
