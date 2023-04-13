using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CorruptionReductionScript : MonoBehaviour
{
    [SerializeField] VisualEffect _playerEffect;
    private PlayerStats _playerStats;



    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        Transform newEffect = Instantiate(_playerEffect, _playerStats.transform.position, Quaternion.identity).transform;
        newEffect.localScale = Vector3.one * 2;
        Destroy(newEffect.gameObject, 2);

        _playerStats.ReduceCorruption(20, false);
        AudioController.Instance.PlaySound(9);
        Destroy(gameObject);
    }
}
