using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    //[Header("====References====")]
    //[SerializeField] TextMeshProUGUI _scoreText;


    [Space(20)]
    [Header("====Debug====")]
    [SerializeField] int _score;
    [SerializeField] int _highScore;
    [SerializeField] string _difficultyName;

    private bool _canScore;

    private void Start()
    {
        _score = 0;
    }


    private void AddScore()
    {
        if (!_canScore) return;

        _score++;
        CheckHighScore();

        CanvasController.Instance.UpdateScores(_score, _highScore);
    }
    private void CheckHighScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore_" + _difficultyName, _highScore);
        }
    }





    public void GetHighScore()
    {
        if (!PlayerPrefs.HasKey("HighScore_" + _difficultyName))
            PlayerPrefs.SetInt("HighScore_" + _difficultyName, 0);

        _highScore = PlayerPrefs.GetInt("HighScore_" + _difficultyName);

        CanvasController.Instance.UpdateScores(0, _highScore);
    }
    public void ToggleScore(bool enable)
    {
        _canScore = enable;
    }
    public void SetDifficultyName(string name)
    {
        _difficultyName = name;
        GetHighScore();
    }





    private void OnEnable()
    {
        EnemyStats.Death += AddScore;
    }
    private void OnDisable()
    {
        EnemyStats.Death -= AddScore;
    }
}
