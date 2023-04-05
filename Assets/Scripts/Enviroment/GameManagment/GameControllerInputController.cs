using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerInputController : MonoBehaviour
{
    private GameControllerInputs _inputs;

    public delegate void GameControllerInputEvent();
    public static event GameControllerInputEvent PauseEvent;



    private void Awake()
    {
        _inputs = new GameControllerInputs();
    }
    private void Start()
    {
        _inputs.Game.Pause.performed += ctx => PauseEvent();
    }






    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }
}
