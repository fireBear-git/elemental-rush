using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptables/Action/Create ActionStringScriptable", fileName = "New ActionString")]
public class ScriptableActionString : ScriptableObject
{
    [SerializeField] private Action<string> _action;

    public void AddListener(Action<string> action)
    {
        _action += action; 
    }
    public void RemoveListener(Action<string> action)
    {
        _action -= action;
    }

    public void Invoke(string value)
    {
        _action?.Invoke(value);
    }
}
