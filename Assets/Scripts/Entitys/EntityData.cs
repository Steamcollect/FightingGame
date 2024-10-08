using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Game/Entity")]
public class EntityData : ScriptableObject
{
    [Header("Main informations")]
    public string entityName;

    [Header("Statistics")]
    public int attackDamage;
    public int maxHealth;
    public int healPower;
    public int shieldPower;
    [Space(5)]
    [Tooltip("Priority order during a scene")] public int priority;
}