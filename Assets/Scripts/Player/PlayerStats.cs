using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerStats : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TextMeshProUGUI _corruptionText;
    [SerializeField] Material _baseMaterial;
    [SerializeField] Material _corruptionMaterial;
    [SerializeField] Material _finalMaterial;
    [SerializeField] VisualEffect _playerHitEffect;



    [Space(20)]
    [Header("====Debug====")]
    [Range(0, 100)]
    [SerializeField] float _corruptionLevel;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _corruptionIncreaseStrength;


    private bool _isCorrupted;


    public delegate void PlayerStatsEvent();
    public static event PlayerStatsEvent Corrupted;


    private bool _canCorrupt;










    private void Start()
    {
        ResetCorruption();
    }
    private void Update()
    {
        UpdateColor();
    }












    private void IncreaseCorruption()
    {
        if (!_canCorrupt) return;

        _corruptionLevel += _corruptionIncreaseStrength;
        _corruptionLevel = Mathf.Clamp(_corruptionLevel, 0, 100);

        _corruptionText.text = "Corruption: " + _corruptionLevel + "%";

        if(_corruptionLevel == 100 && !_isCorrupted)
        {
            _isCorrupted = true;
            Corrupted();
        }
    }

    private void UpdateColor()
    {
        _finalMaterial.color = Color.Lerp(_baseMaterial.color, _corruptionMaterial.color, _corruptionLevel/100);

        _playerHitEffect.SetVector4("ParticleColor", _finalMaterial.color);
    }








    public void ReduceCorruption(int corruptionReduction, bool overrideBlockade)
    {
        if (!_canCorrupt && !overrideBlockade) return;

        _corruptionLevel -= corruptionReduction;
        _corruptionLevel = Mathf.Clamp(_corruptionLevel, 0, 100);

        _corruptionText.text = "Corruption: " + _corruptionLevel + "%";
    }
    public void ResetCorruption()
    {
        _corruptionLevel = 0;
        _corruptionText.text = "Corruption: " + _corruptionLevel + "%";
    }
    public void ToggleCorruption(bool enable)
    {
        _canCorrupt = enable;
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
