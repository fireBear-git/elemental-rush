using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackStatus
{
    still, 
    
    trying,

    tryingSpecial,

    done
}

[RequireComponent(typeof(Rigidbody))]
public class Attack : CharacterBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _maxFury = 4f;
    
    [Header("Scriptables Actions")]
    [SerializeField] private ScriptableActionFloat _specialAttackAction;
    [SerializeField] private ScriptableAction _onHitDone;

    private float _actualFury;

    public AttackStatus status { get; private set; }

    public float damage => _selected.actualProperties.strenght;

    #region Unity Callbacks

    private void Start()
    {
        _actualFury = 0f;
        _specialAttackAction?.Invoke(_actualFury / _maxFury);
    }

    private void OnTriggerExit(Collider other)
    {
        if(status == AttackStatus.done)
            status = AttackStatus.still;
    }

    #endregion

    private void SetAnimatorByStatus()
    {
        _selected.SetTrigger(status.ToString());
    }

    public void Hit()
    {
        status = AttackStatus.trying;
        SetAnimatorByStatus();
    }

    public void SpecialHit()
    {
        if(_actualFury > 1f)
        {
            _actualFury--;
            status = AttackStatus.tryingSpecial;
            SetAnimatorByStatus();
            _specialAttackAction?.Invoke(_actualFury / _maxFury);
        }
    }
    
    public void Done()
    {
        if(status != AttackStatus.tryingSpecial)
        {
            _actualFury += 0.2f;
            status = AttackStatus.done;
        }
        
        _onHitDone?.Invoke();
        _specialAttackAction?.Invoke(_actualFury / _maxFury);
    }


    public void SpecialDone()
    {
        status = AttackStatus.still;
    }
}