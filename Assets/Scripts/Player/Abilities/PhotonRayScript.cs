using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PhotonRayScript : MonoBehaviour
{
    [Range(0, 20)]
    [SerializeField] float _damage;
    [Range(0, 20)]
    [SerializeField] float _duration;
    [SerializeField] LayerMask _rayMask;
    [SerializeField] VisualEffect _rayHit;

    private float _distance;
    private Transform _player;
    [SerializeField] float _width;
    private Vector3 _hitPosition;


    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        transform.parent = _player;
        transform.rotation = _player.rotation;
    }
    private void Start()
    {
        LeanTween.value(0, 0.2f, 0.5f).setOnUpdate((float val) =>
        {
            _width = val;
        });
        StartCoroutine(Hide());
    }

    private void Update()
    {
        SetRayVisuals();
    }


    private float GetDistance()
    {
        RaycastHit2D rayInfo = Physics2D.Raycast(_player.position, _player.up, Mathf.Infinity, _rayMask);
        _hitPosition = rayInfo.point;
        return rayInfo.distance * 2;
    }

    private void SetRayVisuals()
    {
        transform.localScale = new Vector3(_width, GetDistance(), 1);

        if (_width <= 0.001f) return;

        Transform newEffect = Instantiate(_rayHit, _hitPosition, Quaternion.identity).transform;
        newEffect.localScale = Vector3.one * (_width * 3);
        Destroy(newEffect.gameObject, 1f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<EnemyStats>()?.TakeDamage(_damage);
    }



    IEnumerator Hide()
    {
        yield return new WaitForSeconds(_duration);
        LeanTween.value(0.2f, 0, 0.5f).setOnUpdate((float val) =>
        {
            _width = val;
        }).setOnComplete(() =>
        {
            Destroy(gameObject, _duration);
        });
    }
}
