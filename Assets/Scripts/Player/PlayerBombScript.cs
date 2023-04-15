using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PlayerBombScript : MonoBehaviour
{
    [SerializeField] VisualEffect _effect;
    [SerializeField] LayerMask _enemyMask;
    [Range(0, 10)] [SerializeField] float _radius;
    [Range(0, 50)] [SerializeField] float _timeToExplosionMin;
    [Range(0, 50)] [SerializeField] float _timeToExplosionMax;



    private float _timeToExplosion;
    private bool _exploded;
    private Transform _player;


    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        _timeToExplosion = Random.Range(_timeToExplosionMin, _timeToExplosionMax+1);
    }

    private void Update()
    {
        ExplosionTimer();
    }

    private void ExplosionTimer()
    {
        _timeToExplosion -= 10 * Time.deltaTime;
        _timeToExplosion = Mathf.Clamp(_timeToExplosion, 0, 100);

        if (_exploded) return;

        if (_timeToExplosion == 0) Explode();
    }


    private void Explode()
    {
        _exploded = true;

        AudioController.Instance.PlaySound(16);

        VisualEffect newEffect = Instantiate(_effect, transform.position, Quaternion.identity);
        newEffect.transform.localScale = transform.localScale;
        Destroy(newEffect.gameObject, 3);

        ShakeScript.Instance.Shake(transform.localScale.x, 5);

        Collider2D[] enemies = GetNerbyEnemies();
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyStats>()?.Die();
        }
        Destroy(gameObject);
    }



    private Collider2D[] GetNerbyEnemies()
    {
        return Physics2D.OverlapCircleAll(transform.position, transform.localScale.x * _radius, _enemyMask);
    }
}
