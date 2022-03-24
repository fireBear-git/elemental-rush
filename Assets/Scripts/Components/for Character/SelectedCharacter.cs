using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    [Header("Scriptable")]
    [SerializeField] private CharactersScriptable scriptable;

    [SerializeField] private Animator _animator;

    [Header("for tests only")]
    [SerializeField] private string _characterId;

    private Character _character;

    private bool _isBerserk = false;

    public CharacterProperties actualProperties
    {
        get
        {
            if (_isBerserk)
                return _character.berserkProperties;
            else
                return _character.mainProperties;
        }
    }

    void Awake()
    {
        _character = scriptable?.GetCharacter(_characterId);
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void SetFloat(string floatName, float value)
    {
        _animator.SetFloat(floatName, value);
    }
}