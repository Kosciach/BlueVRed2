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
    private bool _emitDeath;

    public delegate void EnemyStatsEvent();
    public static event EnemyStatsEvent Death;
    public static event EnemyStatsEvent PlayerCollision;

    private void Awake()
    {
        _emitDeath = false;
    }
    private void Start()
    {
        _health = Random.Range(25, 101);
        _enemyMovementController.UpdateSpeed(1.1f - (_health / 100));
    }
    private void Update()
    {
        if (_health < 15 && _health > 0) TakeDamage(30 * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * (_health / 100) * 2, _scaleRescaleSpeed * 10 * Time.deltaTime);
    }


    public void TakeDamage(float takenDamage)
    {
        _health -= takenDamage;
        _health = Mathf.Clamp(_health, 0, 100);

        _enemyMovementController.UpdateSpeed(1.1f-(_health/100));

        if (_health <= 0) Die();
    }
    public void Die()
    {
        if (_isDead) return;

        _isDead = true;

        if(_emitDeath) Death();
        ShakeScript.Instance.Shake(2, 10);
        AudioController.Instance.PlaySound(3);
        Instantiate(_enemyDeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ToggleEmitDeath(bool enable)
    {
        _emitDeath = enable;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCollision();
            Die();
        }
        else if (collision.CompareTag("PlayerShield")) Die();
    }




    private void OnEnable()
    {
        GameController.KillAllEnemies += Die;
    }
    private void OnDisable()
    {
        GameController.KillAllEnemies -= Die;
    }
}
