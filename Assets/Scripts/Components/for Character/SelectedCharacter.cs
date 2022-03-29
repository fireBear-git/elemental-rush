using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _characterId;
    [SerializeField] private GameObject Inputs;


    [Header("Data")]
    [SerializeField] private CharactersScriptable _characters;

    [Header("Events")]
    [SerializeField] private ScriptableAction _matchOver;

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

    #region Unity Callbacks

    void Awake()
    {
        _character = _characters?.GetCharacter(_characterId);
    }

    private void OnEnable()
    {
        _matchOver?.AddListener(DisableAllCharacterBehaviour);
    }

    private void OnDisable()
    {
        _matchOver?.RemoveListener(DisableAllCharacterBehaviour);
    }

    #endregion

    public void SetTrigger(string triggerName)
    {
        _animator.SetTrigger(triggerName);
    }

    public void SetFloat(string floatName, float value)
    {
        _animator.SetFloat(floatName, value);
    }

    private void DisableAllCharacterBehaviour()
    {
        CharacterBehaviour[] behaviours = GetComponents<CharacterBehaviour>();
        Inputs.SetActive(false);

        for(int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].enabled = false;
        }
    }
}