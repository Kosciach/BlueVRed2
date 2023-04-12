using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; } 

    [Header("====References====")]
    [SerializeField] GameObject[] _screens;
    [Space(5)]
    [SerializeField] TextMeshProUGUI[] _difficultyNames;
    [SerializeField] TextMeshProUGUI _abilityName;
    [Space(5)]
    [SerializeField] TextMeshProUGUI[] _scoreTexts;
    [SerializeField] TextMeshProUGUI[] _highScoreTexts;
    [Space(5)]
    [SerializeField] TextMeshProUGUI[] _menuHighScores;
    [SerializeField] DifficultyScript[] _difficulties;

    Dictionary<string, int> _screenKeys = new Dictionary<string, int>();


    private void Awake()
    {
        _screenKeys.Add("MenuScreen", 0);
        _screenKeys.Add("SettingsScreen", 1);
        _screenKeys.Add("HighScoresScreen", 2);
        _screenKeys.Add("CreditsScreen", 3);
        _screenKeys.Add("OriginalScreen", 4);
        _screenKeys.Add("PauseScreen", 5);
        _screenKeys.Add("ResultScreen", 6);
        Instance = this;
    }
    private void Start()
    {
        SetupHighScoreScreen();
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


    public void SetAbilityName(string abilityName)
    {
        _abilityName.text = ("Ability: "+abilityName);
    }


    public void UpdateScores(int score, int highScore)
    {
        for(int i=0; i<_scoreTexts.Length; i++)
        {
            _scoreTexts[i].text = "Score: " + score;
            _highScoreTexts[i].text = "HighScore: " + highScore;
        }
    }


    public void SetupHighScoreScreen()
    {
        for (int i = 0; i < _menuHighScores.Length; i++)
        {
            string currentDifficultyName = _difficulties[i].name;
            _menuHighScores[i].text = currentDifficultyName + ": " + PlayerPrefs.GetInt("HighScore_" + currentDifficultyName);
        }
    }
}
