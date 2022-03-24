using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectedCharacter))]
public abstract class CharacterBehaviour : MonoBehaviour
{
    [Header("Character Behaviour")]
    [SerializeField] protected SelectedCharacter _selected;

    protected void Reset()
    {
        _selected ??= GetComponent<SelectedCharacter>();
    }
}
