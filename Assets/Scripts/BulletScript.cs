using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BulletScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] VisualEffect _bulletHitEffect;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 40)]
    [SerializeField] float _speed;
    [Range(0, 100)]
    [SerializeField] float _damage;


    private void Start()
    {
        _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }

    private void Impact(GameObject hit)
    {
        Instantiate(_bulletHitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

        hit.GetComponent<EnemyStats>()?.TakeDamage(_damage);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("PlayerBullet") || collision.CompareTag("EnergyCircle") || collision.CompareTag("PlayerShield")) return;


        Impact(collision.gameObject);
    }
}
