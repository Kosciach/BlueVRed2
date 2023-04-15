using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ReverseCorruptionScript : MonoBehaviour
{
    [SerializeField] VisualEffect _effect;
    [SerializeField] GameObject _playerBombPrefab;
    [SerializeField] LayerMask _enemyMask;
    [Range(0, 10)] [SerializeField] float _radius;


    private Transform _player;


    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        AudioController.Instance.PlaySound(15);
        ConvertEnemies();
    }




    private Collider2D[] GetNerbyEnemies()
    {
        return Physics2D.OverlapCircleAll(_player.position, _radius, _enemyMask);
    }
    private void ConvertEnemies()
    {
        VisualEffect newEffect = Instantiate(_effect, _player.position, Quaternion.identity);
        newEffect.transform.localScale = Vector3.one * _radius;
        Destroy(newEffect.gameObject, 3);


        Collider2D[] enemies = GetNerbyEnemies();
        foreach(Collider2D enemy in enemies)
        {
            Transform newBomb = Instantiate(_playerBombPrefab, enemy.transform.position, Quaternion.identity).transform;
            newBomb.localScale = enemy.transform.localScale;
            Destroy(enemy.gameObject);
        }

    }
}
