using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Camera _mainCamera;


    [Space(20)]
    [Header("====InputValues====")]
    [SerializeField] Vector3 _movementInputVector; public Vector3 MovementInputVector { get { return _movementInputVector; } }
    [SerializeField] Vector3 _mousePosition; public Vector3 MousePosition { get { return _mousePosition; } }

    private PlayerInputs _playerInputs;


    public delegate void InputEvent();
    public static event InputEvent Shoot;
    public static event InputEvent UseAbility;


    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }
    private void Start()
    {
        _playerInputs.Player.Shoot.performed += ctx => Shoot();
        _playerInputs.Player.UseAbility.performed += ctx => UseAbility();
    }

    private void Update()
    {
        GetMovementInput();
        GetMousePosition();
    }



    private void GetMovementInput()
    {
        Vector2 inputVector = _playerInputs.Player.Move.ReadValue<Vector2>();
        _movementInputVector = new Vector3(inputVector.x, 0f, inputVector.y);
    }
    private void GetMousePosition()
    {
        _mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }



    private void OnEnable()
    {
        _playerInputs.Enable();
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
