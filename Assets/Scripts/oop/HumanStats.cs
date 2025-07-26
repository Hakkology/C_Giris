using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HumanStats", menuName = "ScriptableObjects/HumanStats", order = 1)]
public class HumanStats : ScriptableObject
{
    [Header("Base Attributes")]
    [Tooltip("Strength affects physical damage and total health points.")]
    public int strength;

    [Tooltip("Agility affects movement speed.")]
    public int agility;

    [Tooltip("Intelligence affects magical damage.")]
    public int intelligence;

    public float CalculatePhysicalDamage()
    {
        return strength * 1.5f;  // Basit bir hasar hesaplama form�l�
    }

    public float CalculateMagicalDamage()
    {
        return intelligence * 1.5f;  // Basit bir hasar hesaplama form�l�
    }

    public float CalculateSpeed()
    {
        return 5 + agility * 0.3f;  // Y�r�me h�z�n� agility'e ba�l� olarak hesapla
    }

    public int CalculateHP()
    {
        return strength * 20;  // HP, intelligence ile do�ru orant�l�
    }
}