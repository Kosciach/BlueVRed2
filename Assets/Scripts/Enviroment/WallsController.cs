using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Camera _mainCamera;
    [Space(5)]
    [SerializeField] Transform _leftWall;
    [SerializeField] Transform _upWall;
    [SerializeField] Transform _rightWall;
    [SerializeField] Transform _downWall;



    private void Update()
    {
        SetPositions();
        SetScales();
    }


    private void SetPositions()
    {
        Vector3 horizontalPosition = new Vector3(_mainCamera.orthographicSize * _mainCamera.aspect + 0.5f, 0f, 0f);
        Vector3 verticalPosition = new Vector3(0f, _mainCamera.orthographicSize + 0.5f, 0f);


        _leftWall.position = -horizontalPosition;
        _upWall.position = verticalPosition;
        _rightWall.position = horizontalPosition;
        _downWall.position = -verticalPosition;
    }
    private void SetScales()
    {
        Vector3 horizontalScale = new Vector3(1f, _mainCamera.orthographicSize * 2, 0f);
        Vector3 verticalScale = new Vector3(_mainCamera.orthographicSize * _mainCamera.aspect * 2, 1f, 0f);


        _leftWall.localScale = horizontalScale;
        _upWall.localScale = verticalScale;
        _rightWall.localScale = horizontalScale;
        _downWall.localScale = verticalScale;
    }
}
