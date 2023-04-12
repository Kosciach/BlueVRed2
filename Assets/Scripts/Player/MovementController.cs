using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("====Reference====")]
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] InputController _inputController;
    [SerializeField] Camera _mainCamera;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 40)]
    [SerializeField] float _playerSpeed;
    [Range(0, 40)]
    [SerializeField] float _accelerationSpeed;
    [Range(0, 40)]
    [SerializeField] float _dashSpeed;


    private Vector3 _movementVectorTarget;
    private Vector3 _movementVector;




    public void MovePlayer()
    {
        _movementVectorTarget = new Vector3(_inputController.MovementInputVector.x, _inputController.MovementInputVector.z);
        _movementVector = Vector3.Lerp(_movementVector, _movementVectorTarget, _accelerationSpeed * Time.deltaTime);

        _rigidbody.velocity = _movementVector * _playerSpeed * 10 * Time.deltaTime;
        ClampPosition();
    }
    public void Dash()
    {
        _movementVector = transform.up * _dashSpeed;
        _rigidbody.velocity = _movementVector;
    }




    private void ClampPosition()
    {
        float horizontalPosition = _mainCamera.orthographicSize * _mainCamera.aspect;
        float verticalPosition = _mainCamera.orthographicSize;



        Vector3 clampedPosition = new Vector3
        (
            Mathf.Clamp(transform.position.x, -horizontalPosition, horizontalPosition),
            Mathf.Clamp(transform.position.y, -verticalPosition, verticalPosition),
            0f
        );

        transform.position = clampedPosition;
    }
}
