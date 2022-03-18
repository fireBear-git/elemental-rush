using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Motion))]
[RequireComponent(typeof(PlayerInput))]
public class LocalInput : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Attack _attack;
    [SerializeField] private Defence _defence;
    [SerializeField] private Motion _motion;

    public void Reset()
    {
        _attack ??= GetComponent<Attack>();
        _defence??= GetComponent<Defence>();
        _motion ??= GetComponent<Motion>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _motion?.SetDirection(context.ReadValue<float>());
            return;
        }

        if (context.canceled)
        {
            _motion?.SetDirection(0f);
            return;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            _attack.Hit();
    }

    public void OnSpecialAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            _attack.SpecialHit();
    }

    public void OnDefense(InputAction.CallbackContext context)
    {
        if (!context.started)
            _defence.Raise(context.performed);
    }
}
