using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Defence))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SelectedCharacter))]
public class Health : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _maxAmount;

    [Header("Components")]
    [SerializeField] private Attack _myAttack;
    [SerializeField] private Defence _defence;
    [SerializeField] private SelectedCharacter _selected;

    [Header("Scriptables")]
    [SerializeField] private ScriptableActionFloat _interfaceActions;

    private Attack _enemyAttack;

    private float _actualAmount;

    private void Reset()
    {
        _myAttack ??= GetComponent<Attack>();
        _defence ??= GetComponent<Defence>();
    }

    private void Start()
    {
        _actualAmount = _maxAmount;
        _interfaceActions?.Invoke(_actualAmount / _maxAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_myAttack.status == AttackStatus.trying)
            return;

        if (other.gameObject.isStatic)
            return;

        if (_defence.isRaised)
            return;

        _enemyAttack ??= other.GetComponentInParent<Attack>();

        if (_enemyAttack.status != AttackStatus.trying)
            return;

        TakeHit();
    }

    private void TakeHit()
    {
        _actualAmount -= _enemyAttack.damage;
        _enemyAttack.Done();
        _interfaceActions?.Invoke(_actualAmount / _maxAmount);
        //Animations
    }
}
