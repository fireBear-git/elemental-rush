using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class LocalAttack : MonoBehaviour
{
    [SerializeField] private Attack _attack;

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
            _attack.Hit();
    }
}
