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

    private bool _isBerserk;

    private float _defenseValue;
    private float _defensingTarget;

    public CharacterProperties actualProperties
    {
        get
        {
            if (_isBerserk)
                return _character.mainProperties;
            else
                return _character.berserkProperties;
        }
    }

    void Awake()
    {
        _character = scriptable?.GetCharacter(_characterId);
    }

    private void Update()
    {
        if (_defenseValue != _defensingTarget)
        {
            _defenseValue = Mathf.MoveTowards(_defenseValue, _defensingTarget, Time.deltaTime * 4);
            _animator.SetFloat("defense", _defenseValue);
        }
    }

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void Defense(bool value)
    {
        _defensingTarget = value ? 1f : 0f;
    }
}