using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("====Reference====")]
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] InputController _inputController;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 40)]
    [SerializeField] float _playerSpeed;
    [Range(0, 40)]
    [SerializeField] float _accelerationSpeed;


    private Vector3 _movementVectorTarget;
    private Vector3 _movementVector;



    private void FixedUpdate()
    {
        _movementVectorTarget = new Vector3(_inputController.MovementInputVector.x, _inputController.MovementInputVector.z);
        _movementVector = Vector3.Lerp(_movementVector, _movementVectorTarget, _accelerationSpeed * Time.deltaTime);

        _rigidbody.velocity = _movementVector * _playerSpeed * 10 * Time.deltaTime;
    }
}
