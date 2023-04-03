using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _scoreText;


    [Space(20)]
    [Header("====Debug====")]
    [SerializeField] int _score;
    [SerializeField] int _highScore;

    private bool _canScore;

    private void Start()
    {
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString();
    }
    private void AddScore()
    {
        if (!_canScore) return;

        _score++;
        _scoreText.text = "Score: " + _score.ToString();
    }

    public void ToggleScore(bool enable)
    {
        _canScore = enable;
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
