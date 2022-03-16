using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties
{
    [SerializeField] private float _strenght;
    [SerializeField] private float _dexterity;

    public float strenght => _strenght;
    public float Dexterity => _dexterity; 
}
