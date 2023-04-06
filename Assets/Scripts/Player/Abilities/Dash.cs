using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    private MovementController _movementController;
    private PlayerStats _playerStats;

    private void Awake()
    {
        _movementController = FindObjectOfType<MovementController>();
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        Destroy(gameObject, 0.5f);
        _playerStats.ToggleCorruption(false);
        _movementController.Dash();
    }


    private void OnDestroy()
    {
        _playerStats.ToggleCorruption(true);
    }
}
