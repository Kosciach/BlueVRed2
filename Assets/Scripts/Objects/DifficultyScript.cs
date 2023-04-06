using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "ScriptableObjects/Difficulty")]
public class DifficultyScript : ScriptableObject
{
    public string DifficultyName;
    [Range(0, 300)]
    public float MaxEnemySpawnRateIncrease;
    [Range(0, 100)]
    public float EnemySpawnRateIncrease;
    [Range(0, 20)]
    public int EnemiesToSpawnRateIncrease;
}
