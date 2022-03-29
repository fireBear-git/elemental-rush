using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Conclusion : MonoBehaviour
{
    [Header("Childs Components")]
    [SerializeField] private Text _text;

    [Header("Events")]
    [SerializeField] private ScriptableActionString _matchWinner;
    [SerializeField] private ScriptableActionString _battleWinner;

    #region Unity Callbacks

    private void Reset()
    {
        _text ??= GetComponentInChildren<Text>();
    }

    void Start()
    {
        SetTextActive(false);
    }

    private void OnEnable()
    {
        _matchWinner?.AddListener(MatchWinner);
        _battleWinner?.AddListener(BattleWinner);
    }

    private void OnDisable()
    {
        _matchWinner?.RemoveListener(MatchWinner);
        _battleWinner?.RemoveListener(BattleWinner);
    } 

    #endregion

    private void SetTextActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void MatchWinner(string winner)
    {
        _text.text = $"{winner} wins this match";
        SetTextActive(true);
    }

    public void BattleWinner(string winner)
    {
        _text.text = $"{winner} wins the battle";
        SetTextActive(true);
    }
}
