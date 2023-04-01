using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    private Transform _player;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void RotateToPlayer()
    {
        float diffX = _player.position.x - transform.position.x;
        float diffY = _player.position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg + 270;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
