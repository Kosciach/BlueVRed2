using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _shootingPoint;


    private void Shoot()
    {
        Instantiate(_bulletPrefab, _shootingPoint.position, transform.rotation);
    }


    private void OnEnable()
    {
        InputController.Shoot += Shoot;
    }
    private void OnDisable()
    {
        InputController.Shoot -= Shoot;
    }
}
