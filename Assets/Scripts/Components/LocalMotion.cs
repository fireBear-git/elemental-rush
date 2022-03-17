using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class LocalMotion : MonoBehaviour
{
    [SerializeField] private Motion _motion;

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
}
