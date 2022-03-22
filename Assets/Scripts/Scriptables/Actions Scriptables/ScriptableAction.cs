using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Action/Create ActionScriptable", fileName = "New Action")]
public class ScriptableAction : ScriptableObject
{
    private Action _action;

    public void AddListener(Action action)
    {
        _action += action;
    }

    public void RemoveListener(Action action)
    {
        _action -= action;
    }

    public void Invoke()
    {
        _action?.Invoke();
    }
}
