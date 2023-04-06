using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody;



    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] float _speedScale;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 40)]
    [SerializeField] float _speed;

    

    public void MoveToPlayer()
    {
        _rigidbody.velocity = transform.up * _speedScale * _speed * 10 * Time.deltaTime;
    }
    public void MoveGameOver()
    {
        _rigidbody.velocity = transform.up * (5-_speedScale) * _speed  * Time.deltaTime;
    }
    public void UpdateSpeed(float health)
    {
        _speedScale = health;
    }
}
