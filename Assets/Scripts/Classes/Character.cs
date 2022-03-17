using System;
using UnityEngine;

[Serializable]
public class Character 
{
    [SerializeField] private string _name;
    [SerializeField] private string _id;
    [SerializeField] private CharacterProperties _mainProperties;
    [SerializeField] private CharacterProperties _berserkProperties;

    public string name => _name; 
    public string id => _id;
    public CharacterProperties mainProperties => _mainProperties;
    public CharacterProperties berserkProperties => _berserkProperties;
}
