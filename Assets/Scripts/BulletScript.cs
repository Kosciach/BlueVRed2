using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 40)]
    [SerializeField] float _speed;



    private void Start()
    {
        _rigidbody.AddForce(transform.up * _speed, ForceMode2D.Impulse);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
