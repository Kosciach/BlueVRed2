using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Camera _mainCamera;

    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] float _spawnRateIncrease;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _timeBetweenSpawns;
    [Range(0, 100)]
    [SerializeField] float _timeToSpawn;
    [Range(0, 20)]
    [SerializeField] float _spawnSpeed;
    [Space(5)]
    [SerializeField] Vector3[] _spawnPoints;
    [SerializeField] int[] _directors;


    [Space(20)]
    [Header("====Switches====")]
    [SerializeField] SwitchesClass _swiches; public SwitchesClass Switches { get { return _swiches; } set { _swiches = value; } }

    [System.Serializable]
    public class SwitchesClass
    {
        public bool Menu;
        public bool MoveToPlayer;
        public bool GameOver;
    }




    private void Start()
    {
        _timeToSpawn = _timeBetweenSpawns;
        _spawnPoints = new Vector3[4];
    }

    private void Update()
    {
        SpawnTimer();
    }






    public void IncreaseSpawnRate(float spawnRateIncease, float maxSpawnRateIncrease)
    {
        if(_spawnRateIncrease < maxSpawnRateIncrease) _spawnRateIncrease += spawnRateIncease;
        _spawnRateIncrease = Mathf.Clamp(_spawnRateIncrease, 0, maxSpawnRateIncrease); 
    }
    private void SpawnTimer()
    {
        _timeToSpawn -= (_spawnSpeed * 10 + _spawnRateIncrease) * Time.deltaTime;
        _timeToSpawn = Mathf.Clamp(_timeToSpawn, 0, _timeBetweenSpawns);

        if(_timeToSpawn <= 0)
        {
            Spawn();
            _timeToSpawn = _timeBetweenSpawns;
        }
    }
    private void Spawn()
    {

        _spawnPoints[0] = (Vector3.right * _mainCamera.orthographicSize * _mainCamera.aspect);
        _spawnPoints[1] = -_spawnPoints[0];

        _spawnPoints[2] = Vector3.up * 10;
        _spawnPoints[3] = -_spawnPoints[2];

        int index = Random.Range(0, 4);
        int offsetIndex = Random.Range(0, 2);

        Vector3 offset;
        if (index < 2) offset = Vector3.up * _mainCamera.orthographicSize * _directors[offsetIndex];
        else offset = Vector3.right * _mainCamera.orthographicSize * _mainCamera.aspect * _directors[offsetIndex];

        Vector3 spawnPoint = _spawnPoints[index] + offset;


        Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity).GetComponent<EnemyStateMachine>().EnemySpawner = this;
    }
}
