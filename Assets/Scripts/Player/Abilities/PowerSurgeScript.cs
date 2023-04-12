using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSurgeScript : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [Range(0, 1)] [SerializeField] float _fireRate;
    [Range(0, 100)][SerializeField] int _bulletCount;


    private Transform _player;


    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }
    private void Start()
    {
        transform.parent = _player;
        StartCoroutine(Fire());
    }










    private IEnumerator Fire()
    {
        for(int i=0; i<_bulletCount; i++)
        {
            Instantiate(_bulletPrefab, _player.GetChild(1).position, _player.rotation);
            yield return new WaitForSeconds(_fireRate);
        }
        Destroy(gameObject);
        Debug.Log("Booooooooooooooooooooooooooom");
    }
}
