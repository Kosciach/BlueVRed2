using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathCircle : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [Range(0, 10)]
    [SerializeField] float _expandSpeed;





    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        transform.LeanScale(Vector3.one * _mainCamera.orthographicSize * 3.5f, _expandSpeed).setEaseOutCirc().setOnComplete(() =>
        {
            Debug.Log("The end game");
        });
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyStats>()?.Die();
    }
}
