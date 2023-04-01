using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] InputController _inputController;
    [SerializeField] Transform _aimTarget;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _aimDelay;
    [Range(0, 20)]
    [SerializeField] float _turretDetectionRadius;
    [SerializeField] LayerMask _enemyMask;



    private void Update()
    {
        MovePlayerAimTarget();
    }

    private void MovePlayerAimTarget()
    {
        _aimTarget.position = Vector3.Lerp(_aimTarget.position, _inputController.MousePosition, _aimDelay * Time.deltaTime);
    }
    public void RotateToMouse()
    {
        float diffX = _aimTarget.position.x - transform.position.x;
        float diffY = _aimTarget.position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void TurretRotation()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _turretDetectionRadius, _enemyMask);
        if (enemies.Length <= 0) return;

        float distance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach(Collider2D enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }


        float diffX = closestEnemy.position.x - transform.position.x;
        float diffY = closestEnemy.position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
