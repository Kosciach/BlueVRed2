using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathCircle : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [Range(0, 10)]
    [SerializeField] float _expandDuration;

    public delegate void DeathCircleEvent();
    public static event DeathCircleEvent CircleEnded;




    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Start()
    {
        transform.LeanScale(Vector3.one * _mainCamera.orthographicSize * 3.01f, _expandDuration).setOnComplete(() =>
        {
            Debug.Log("The end game");
            CircleEnded();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<EnemyStats>()?.Die();
    }
}
