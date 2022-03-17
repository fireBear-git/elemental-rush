using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Health : MonoBehaviour
{
    [Header("for tests only")]
    [SerializeField] private float _maxAmount;
    [SerializeField] private Attack _myAttack;

    private Attack _enemyAttack;

    private float _actualAmount;

    public float amount => _actualAmount / _maxAmount;

    private void Reset()
    {
        _myAttack ??= GetComponent<Attack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_myAttack.status == AttackStatus.trying)
            return;

        _enemyAttack ??= other.GetComponent<Attack>();
        TakeHit();
    }

    private void TakeHit()
    {
        _actualAmount -= _enemyAttack.damage;
        _enemyAttack.Done();

        //Animations & UI feedback
    }
}
