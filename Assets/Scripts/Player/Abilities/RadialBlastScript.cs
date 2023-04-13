using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBlastScript : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float _enterSpeed;
    [Range(0, 10)]
    [SerializeField] float _staySpeed;
    [Range(0, 10)]
    [SerializeField] float _exitSpeed;

    private void Start()
    {
        AudioController.Instance.PlaySound(7);
        transform.LeanScale(Vector3.one * 2, _enterSpeed).setEaseOutQuart().setOnComplete(() =>
        {
            transform.LeanScale(Vector3.one * 2.1f, _staySpeed).setOnComplete(() =>
            {
                AudioController.Instance.PlaySound(8);
                transform.LeanScale(Vector3.zero, _exitSpeed).setEaseInBack().setOnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
        });
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>().Die();
        }
    }
}
