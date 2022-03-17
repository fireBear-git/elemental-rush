using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectedCharacter))]
public class Attack : MonoBehaviour
{
    [SerializeField] private SelectedCharacter _selected;

    public float strenght => _selected.actualProperties.strenght;

    private void Reset() => _selected ??= GetComponent<SelectedCharacter>();
}
