using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "ScriptableObjects/Ability")]
public class Ability : ScriptableObject
{
    public string Name;
    public float DropChance;
    public GameObject AbilityPrefab;
}
