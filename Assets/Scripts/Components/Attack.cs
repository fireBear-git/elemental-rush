using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackStatus
{
    still, 
    
    trying,

    hit
}

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SelectedCharacter))]
public class Attack : MonoBehaviour
{
    [SerializeField] private SelectedCharacter _selected;

    public AttackStatus status { get; private set; }

    public float damage => _selected.actualProperties.strenght;

    private void Reset()
    {
        _selected ??= GetComponent<SelectedCharacter>();
    }

    private void OnTriggerExit(Collider other)
    {
        status = AttackStatus.still;
    }

    public void Done()
    {
        status = AttackStatus.hit;
    }
}
