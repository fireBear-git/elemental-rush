using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private CharactersScriptable scriptable;

    [Header("for tests only")]
    [SerializeField] private string _characterId;

    private Character _character;

    private bool _isBerserk;

    public CharacterProperties actualProperties => _isBerserk ? _character.mainProperties : _character.berserkProperties;

    void Awake() => _character = scriptable?.GetCharacter(_characterId);
}