using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private EnemyBaseState _currentState; public EnemyBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    private EnemyStateFactory _factory;
    [SerializeField] string _currentStateName; public string CurrentStateName { get { return _currentStateName; } set { _currentStateName = value; } }



    [Space(20)]
    [Header("====EnemyScripts====")]
    [SerializeField] EnemyMovementController _movementController; public EnemyMovementController MovementController { get { return _movementController; } }
    [SerializeField] EnemyRotator _rotator; public EnemyRotator Rotator { get { return _rotator; } }
    [SerializeField] EnemyStats _enemyStats; public EnemyStats EnemyStats { get { return _enemyStats; } }
    [SerializeField] EnemySpawner _enemySpawner; public EnemySpawner EnemySpawner { get { return _enemySpawner; } set { _enemySpawner = value; } }



    private void Awake()
    {
        _factory = new EnemyStateFactory(this);
        _currentState = _factory.Menu();
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
}
