using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyArtilleryScript : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] LayerMask _enemyMask;
    [Range(0, 10)][SerializeField] float _radius;
    [Range(0, 10)][SerializeField] float _duration;
    [Space(5)]
    [Range(0, 30)][SerializeField] float _fireRate;
    [Range(0, 30)][SerializeField] float _timeToShoot;


    private Transform _player;

    private Transform[] _mounts = new Transform[4];
    private Transform _selectedMount;

    private Vector3[] _detectorDirection = new Vector3[2];
    private Vector3 _selectedDirection;

    private bool _onPosition;



    private void Awake()
    {
        _timeToShoot = _fireRate;
        _onPosition = false;

        _player = GameObject.Find("Player").transform;


        for(int i=0; i<4; i++)
            _mounts[i] = _player.GetChild(i+2);

        int index = Random.Range(0, 2);
        _selectedMount = _mounts[index];
        _selectedDirection = _detectorDirection[index];

        transform.parent = _player;
        transform.position = _player.position;
        transform.rotation = _player.rotation;

        MoveToPosition();
        StartCoroutine(Hide());
    }
    private void Update()
    {
        RotateToClosestEnemy();
        ShootingTimer();
    }



    private Collider2D[] GetEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);
    }
    private Transform GetClosestEnemy()
    {
        Collider2D[] enemies = GetEnemies();

        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach(Collider2D enemy in enemies)
        {
            float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);
            if(currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }
    private void RotateToClosestEnemy()
    {
        Transform closestEnemy = GetClosestEnemy();

        if (closestEnemy == null)
        {
            _timeToShoot = _fireRate;
            return;
        }

        float diffX = closestEnemy.GetChild(0).position.x - transform.position.x;
        float diffY = closestEnemy.GetChild(0).position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }


    private void ShootingTimer()
    {
        _timeToShoot -= 10 * Time.deltaTime;
        _timeToShoot = Mathf.Clamp(_timeToShoot, 0, _fireRate);

        if (_timeToShoot == 0) Shoot();
    }
    private void Shoot()
    {
        Instantiate(_bulletPrefab, transform.position, transform.rotation);
        _timeToShoot = _fireRate;
    }



    private void MoveToPosition()
    {
        AudioController.Instance.PlaySound(13);
        transform.LeanMoveLocal(_selectedMount.localPosition, 0.2f).setOnComplete(() => { _onPosition = true; });
    }


    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(_duration);
        _onPosition = false;

        AudioController.Instance.PlaySound(14);
        transform.LeanRotate(_player.rotation.eulerAngles, 0.1f);
        transform.LeanMoveLocal(Vector3.zero, 0.3f).setOnComplete(() => { Destroy(gameObject); });
    }
}
