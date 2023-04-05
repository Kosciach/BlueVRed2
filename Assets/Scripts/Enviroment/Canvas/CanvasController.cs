using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _screens;
    [SerializeField] TextMeshProUGUI[] _difficultyNames;

    Dictionary<string, int> _screenKeys = new Dictionary<string, int>();


    private void Awake()
    {
        _screenKeys.Add("MenuScreen", 0);
        _screenKeys.Add("SettingsScreen", 1);
        _screenKeys.Add("HighScoresScreen", 2);
        _screenKeys.Add("CreditsScreen", 3);
        _screenKeys.Add("OriginalScreen", 4);
        _screenKeys.Add("PauseScreen", 5);
    }
    public void SwitchScreen(string screenKey)
    {
        int keyIndex;
        if (!_screenKeys.TryGetValue(screenKey, out keyIndex))
        {
            Debug.Log("WrongKey!");
            return;
        }
        else Debug.Log(keyIndex);
        for (int i = 0; i < _screens.Length; i++) _screens[i].SetActive(false);
        _screens[keyIndex].SetActive(true);
    }
    public void ChangeDifficultyName(string difficultyName)
    {
        foreach(TextMeshProUGUI difficultyNameText in _difficultyNames) difficultyNameText.text = "Difficulty: "+difficultyName;
    }
}
