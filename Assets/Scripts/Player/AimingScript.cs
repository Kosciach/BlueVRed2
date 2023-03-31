using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] InputController _inputController;
    [SerializeField] Transform _aimTarget;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _aimDelay;



    private void Update()
    {
        MovePlayerAimTarget();
        RotateToMouse();
    }

    private void MovePlayerAimTarget()
    {
        _aimTarget.position = Vector3.Lerp(_aimTarget.position, _inputController.MousePosition, _aimDelay * Time.deltaTime);
    }
    private void RotateToMouse()
    {
        float diffX = _aimTarget.position.x - transform.position.x;
        float diffY = _aimTarget.position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
