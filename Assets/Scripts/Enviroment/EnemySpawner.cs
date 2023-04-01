using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Camera _mainCamera;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _timeBetweenSpawns;
    [Range(0, 100)]
    [SerializeField] float _timeToSpawn;
    [Range(0, 20)]
    [SerializeField] float _spawnSpeed;

    private void Start()
    {
        _timeToSpawn = _timeBetweenSpawns;
    }

    private void Update()
    {
        SpawnTimer();
    }

    private void SpawnTimer()
    {
        _timeToSpawn -= _spawnSpeed * 10 * Time.deltaTime;
        _timeToSpawn = Mathf.Clamp(_timeToSpawn, 0, _timeBetweenSpawns);

        if(_timeToSpawn <= 0)
        {
            Spawn();
            _timeToSpawn = _timeBetweenSpawns;
        }
    }
    private void Spawn()
    {

    }
}
