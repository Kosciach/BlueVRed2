using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _shootingPoint;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _timeBetweenShoots;
    [Range(0, 100)]
    [SerializeField] float _timeToShoot;
    [Range(0, 40)]
    [SerializeField] float _timeToShootMultiplier;
    [SerializeField] bool _canShootFromInput;

    private void Start()
    {
        _timeToShoot = _timeBetweenShoots;
    }



    private void Shoot()
    {
        if(_canShootFromInput) Instantiate(_bulletPrefab, _shootingPoint.position, transform.rotation);
    }
    public void TurretShooting(float distanceToClosestEnemy)
    {
        _timeToShoot -= _timeToShootMultiplier * 10 * (10 - distanceToClosestEnemy) * Time.deltaTime;
        _timeToShoot = Mathf.Clamp(_timeToShoot, 0, _timeBetweenShoots);

        if(_timeToShoot == 0)
        {
            Instantiate(_bulletPrefab, _shootingPoint.position, transform.rotation);
            _timeToShoot = _timeBetweenShoots;
        }
    }
    public void ToggleShootingFromInput(bool enable)
    {
        _canShootFromInput = enable;
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
