using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStats : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] VisualEffect _enemyDeathEffect;
    [SerializeField] EnemyMovementController _enemyMovementController;



    [Space(20)]
    [Header("====Debug====")]
    [Range(0, 100)]
    [SerializeField] float _health;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _scaleRescaleSpeed;

    private bool _isDead;

    public delegate void EnemyStatsEvent();
    public static event EnemyStatsEvent Death;
    public static event EnemyStatsEvent PlayerCollision;


    private void Start()
    {
        _health = Random.Range(25, 101);
        _enemyMovementController.UpdateSpeed(1.1f - (_health / 100));
    }
    private void Update()
    {
        if (_health < 15 && _health > 0) TakeDamage(0.1f);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * (_health / 100) * 2, _scaleRescaleSpeed * 10 * Time.deltaTime);
    }


    public void TakeDamage(float takenDamage)
    {
        _health -= takenDamage;
        _health = Mathf.Clamp(_health, 0, 100);

        _enemyMovementController.UpdateSpeed(1.1f-(_health/100));

        if (_health <= 0) Die();
    }
    private void Die()
    {
        if (_isDead) return;

        _isDead = true;

        Death();
        ShakeScript.Instance.Shake(2, 10);
        Instantiate(_enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCollision();
            Die();
        }
    }
}
