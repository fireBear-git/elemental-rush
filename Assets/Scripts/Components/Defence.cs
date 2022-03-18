using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
    [SerializeField] private SelectedCharacter _selected;
    
    private float _defenseValue;
    private float _defensingTarget;

    public bool isRaised { get; private set; }

    void Reset()
    {
        _selected ??= GetComponent<SelectedCharacter>();
    }

    void Update()
    {
        if (_defenseValue != _defensingTarget)
        {
            _defenseValue = Mathf.MoveTowards(_defenseValue, _defensingTarget, Time.deltaTime * 4);
        }
    }

    public void Raise(bool value)
    {
        isRaised = value;
        _defensingTarget = value ? 1f : 0f;
    }
}
