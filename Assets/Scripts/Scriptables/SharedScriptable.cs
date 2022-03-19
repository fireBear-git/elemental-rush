using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Scriptables/Create SharedScriptable", fileName = "SharedScriptable", order = 21)]
public class SharedScriptable : ScriptableObject
{
    public void ReloadControlScheme(PlayerInput playerInput)
    {
        if (playerInput.currentControlScheme == null && Gamepad.all.Count == 0)
            playerInput.SwitchCurrentControlScheme(playerInput.defaultControlScheme, Keyboard.current);
    }
}
