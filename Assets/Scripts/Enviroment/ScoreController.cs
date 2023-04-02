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


    private void Start()
    {
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString();
    }
    private void AddScore()
    {
        _score++;
        _scoreText.text = "Score: " + _score.ToString();
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
