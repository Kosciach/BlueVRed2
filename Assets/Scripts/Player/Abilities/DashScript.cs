using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] float _duration;

    private MovementController _movementController;
    private PlayerStats _playerStats;

    private void Awake()
    {
        _movementController = FindObjectOfType<MovementController>();
        _playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        transform.parent = _playerStats.transform;
        transform.localPosition = new Vector3(0, 0.64f, 0);
        transform.LeanScale(new Vector3(1.36f, 1, 1), 0.2f);
        transform.rotation = _playerStats.transform.rotation;

        _playerStats.ToggleCorruption(false);
        _movementController.Dash();
        AudioController.Instance.PlaySound(5);

        StartCoroutine(HideShield());
    }


    IEnumerator HideShield()
    {
        yield return new WaitForSeconds(_duration);

        transform.LeanScale(Vector3.zero, 0.2f).setOnComplete(() =>
        {
            _playerStats.ToggleCorruption(true);
            Destroy(gameObject);
        });
    }
}
