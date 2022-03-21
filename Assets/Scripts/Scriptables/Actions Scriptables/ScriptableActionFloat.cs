using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Action/Create ActionFloatScriptable", fileName = "New ActionFloat")]
public class ScriptableActionFloat : ScriptableObject
{
    private Action<float> _action;

    public void AddListener(Action<float> action)
    {
        _action += action;
    }

    public void RemoveListener(Action<float> action)
    {
        _action -= action;
    }

    public void Invoke(float amount)
    {
        _action?.Invoke(amount);
    }
}
