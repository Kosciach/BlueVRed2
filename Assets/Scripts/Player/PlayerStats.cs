using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _corruptionText;
    [SerializeField] Material _corruptionMaterial;


    [Space(20)]
    [Header("====Debug====")]
    [Range(0, 100)]
    [SerializeField] float _corruptionLevel;



    [Space(20)]
    [Header("====Debug====")]
    [Range(0, 100)]
    [SerializeField] float _corruptionIncreaseStrength;


    private bool _isCorrupted;


    public delegate void PlayerStatsEvent();
    public static event PlayerStatsEvent Corrupted;



    private void Start()
    {
        _corruptionLevel = 0;
        _corruptionMaterial.color = new Color(_corruptionMaterial.color.r, _corruptionMaterial.color.g, _corruptionMaterial.color.b, _corruptionLevel);
        _corruptionText.text = "Corruption: " + _corruptionLevel + "%";
    }
    private void IncreaseCorruption()
    {
        _corruptionLevel += _corruptionIncreaseStrength;
        _corruptionLevel = Mathf.Clamp(_corruptionLevel, 0, 100);

        _corruptionMaterial.color = new Color(_corruptionMaterial.color.r, _corruptionMaterial.color.g, _corruptionMaterial.color.b, _corruptionLevel/100);
        _corruptionText.text = "Corruption: " + _corruptionLevel + "%";

        if(_corruptionLevel == 100 && !_isCorrupted)
        {
            _isCorrupted = true;
            Corrupted();
        }
    }


    private void OnEnable()
    {
        EnemyStats.PlayerCollision += IncreaseCorruption;
    }
    private void OnDisable()
    {
        EnemyStats.PlayerCollision -= IncreaseCorruption;
    }
}
