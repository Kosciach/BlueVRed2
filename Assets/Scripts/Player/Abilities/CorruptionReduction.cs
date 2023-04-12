using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionReduction : MonoBehaviour
{
    private PlayerStats _playerStats;



    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        _playerStats.ReduceCorruption(20, false);
        Destroy(gameObject);
    }
}
