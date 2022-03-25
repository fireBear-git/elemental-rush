using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Defence))]
[RequireComponent(typeof(Rigidbody))]
public class Health : CharacterBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _maxAmount;

    [Header("Components")]
    [SerializeField] private Attack _myAttack;
    [SerializeField] private Defence _defence;

    [Header("Actions")]
    [SerializeField] private ScriptableActionFloat _amountChanged;
    [SerializeField] private ScriptableActionString _winningCharacter;
    [SerializeField] private ScriptableAction _reloadGameScene;


    private Attack _enemyAttack;

    private float _actualAmount;

    private new void Reset()
    {
        base.Reset();
        _myAttack ??= GetComponent<Attack>();
        _defence ??= GetComponent<Defence>();
    }

    private void Start()
    {
        _actualAmount = _maxAmount;
        _amountChanged?.Invoke(_actualAmount / _maxAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_myAttack.status == AttackStatus.trying || _myAttack.status == AttackStatus.tryingSpecial)
            return;

        if (other.gameObject.isStatic)
            return;

        if (_defence.isRaised)
            return;

        _enemyAttack ??= other.GetComponentInParent<Attack>();

        if (_enemyAttack.status == AttackStatus.still)
            return;

        TakeHit();
    }

    private void TakeHit()
    {
        _actualAmount -= _enemyAttack.damage;
        _enemyAttack.Done();
        _amountChanged?.Invoke(_actualAmount / _maxAmount);

        if (_actualAmount <= 0)
        {
            _winningCharacter?.Invoke(_enemyAttack.name);
            _reloadGameScene?.Invoke();
        }


        //Animations
    }
}
