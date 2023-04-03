using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _screens;




    public void SwitchScreen(int screenIndex)
    {
        for (int i = 0; i < _screens.Length; i++) _screens[i].SetActive(false);
        _screens[screenIndex].SetActive(true);
    }
}
