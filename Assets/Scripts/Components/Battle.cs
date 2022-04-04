using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    [Header("Scriptables")]
    [SerializeField] private WinsScriptable _winsScriptable;

    [Header("Events")]
    [SerializeField] private ScriptableActionString _winnerCharacter;

    [Header("Invoke only")]
    [SerializeField] private ScriptableAction _matchOver;
    [SerializeField] private ScriptableAction _reloadMatch;
    
    [Header("UI Actions")]
    [SerializeField] private ScriptableActionString _matchWinner;
    [SerializeField] private ScriptableActionString _battleWinner;

    [Header("FOR TEST ONLY")]
    [SerializeField] private int _maxWins;

    private int _minforWin => (_maxWins / 2) + 1;

    public static bool isOver = false;

    public static bool loaded = false;

    #region Unity Callbacks

    void Start()
    {
        if (!loaded)
        {
            loaded = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _winsScriptable.Reset();
    }

    private void OnEnable()
    {
        _winnerCharacter.AddListener(onWin);
    }

    private void OnDisable()
    {
        _winnerCharacter.RemoveListener(onWin);
    }

    #endregion

    private void onWin(string winner)
    {
        int actualWins = _winsScriptable.Win(winner);

        _matchOver.Invoke();

        if (actualWins == _minforWin)
        {
            isOver = true;
            _battleWinner.Invoke(winner);
            return;
        }

        _matchWinner.Invoke(winner);
        _reloadMatch.Invoke();
    }
}
