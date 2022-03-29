using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Create WinsScriptable", fileName = "WinsScriptable")]
public class WinsScriptable : ScriptableObject
{
    private Dictionary<string, int> _wins = new Dictionary<string, int>();

    public void Reset()
    {
        _wins.Clear();
    }
        
    public int Win(string winner)
    {
        if (_wins.ContainsKey(winner))
            _wins[winner]++;
        else
            _wins.Add(winner, 1);
        
        return _wins[winner];
    }
}
