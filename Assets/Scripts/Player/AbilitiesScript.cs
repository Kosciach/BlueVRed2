using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesScript : MonoBehaviour
{
    [SerializeField] Ability[] _abilities;
    [SerializeField] Ability _currentAbility;


    private void DrawAbility()
    {
        if (_currentAbility != null) return;

        int index = Random.Range(0, _abilities.Length);
        int chance = Random.Range(0, 101);
        Ability tempAbility = _abilities[index];


        //Get ability
        if (tempAbility.DropChance > chance)
        {
            _currentAbility = tempAbility;
            CanvasController.Instance.SetAbilityName(_currentAbility.name);
        }
    }
    private void UseAbility()
    {
        if (_currentAbility == null) return;

        Debug.Log("Use Ability!");
        Instantiate(_currentAbility.AbilityPrefab, transform.position, Quaternion.identity);
        _currentAbility = null;
        CanvasController.Instance.SetAbilityName("-------");
    }



    private void OnEnable()
    {
        EnemyStats.Death += DrawAbility;
        InputController.UseAbility += UseAbility;
    }
    private void OnDisable()
    {
        EnemyStats.Death -= DrawAbility;
        InputController.UseAbility -= UseAbility;
    }
}
