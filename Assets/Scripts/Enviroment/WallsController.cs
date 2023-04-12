using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Camera _mainCamera;
    [Space(5)]
    [SerializeField] SpriteRenderer _leftWall;
    [SerializeField] SpriteRenderer _upWall;
    [SerializeField] SpriteRenderer _rightWall;
    [SerializeField] SpriteRenderer _downWall;

    private bool _wallsVisible;

    private void Start()
    {
        _wallsVisible = PlayerPrefs.GetInt("VisibleWalls") == 0 ? false : true;

        _leftWall.enabled = _wallsVisible;
        _upWall.enabled = _wallsVisible;
        _rightWall.enabled = _wallsVisible;
        _downWall.enabled = _wallsVisible;

        string visibleWallsText = _wallsVisible ? "Yes" : "No";
        CanvasController.Instance.VisibleWallsTextSwitch(visibleWallsText);
    }
    private void Update()
    {
        SetPositions();
        SetScales();
    }


    private void SetPositions()
    {
        Vector3 horizontalPosition = new Vector3(_mainCamera.orthographicSize * _mainCamera.aspect + 0.5f, 0f, 0f);
        Vector3 verticalPosition = new Vector3(0f, _mainCamera.orthographicSize + 0.5f, 0f);


        _leftWall.transform.position = -horizontalPosition;
        _upWall.transform.position = verticalPosition;
        _rightWall.transform.position = horizontalPosition;
        _downWall.transform.position = -verticalPosition;
    }
    private void SetScales()
    {
        Vector3 horizontalScale = new Vector3(1f, _mainCamera.orthographicSize * 2, 0f);
        Vector3 verticalScale = new Vector3(_mainCamera.orthographicSize * _mainCamera.aspect * 2, 1f, 0f);


        _leftWall.transform.localScale = horizontalScale;
        _upWall.transform.localScale = verticalScale;
        _rightWall.transform.localScale = horizontalScale;
        _downWall.transform.localScale = verticalScale;
    }

    public void SwitchWallsVisuals()
    {
        _wallsVisible = !_wallsVisible;

        int visibleWallsIntConverted = _wallsVisible ? 1 : 0;
        PlayerPrefs.SetInt("VisibleWalls", visibleWallsIntConverted);

        _leftWall.enabled = _wallsVisible;
        _upWall.enabled = _wallsVisible;
        _rightWall.enabled = _wallsVisible;
        _downWall.enabled = _wallsVisible;

        string visibleWallsText = _wallsVisible ? "Yes" : "No";
        CanvasController.Instance.VisibleWallsTextSwitch(visibleWallsText);
    }
}
