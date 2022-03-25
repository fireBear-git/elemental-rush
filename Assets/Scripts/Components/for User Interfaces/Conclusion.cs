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
    [SerializeField] private ScriptableActionString _winningCharacter;

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
        _winningCharacter?.AddListener(SetWinner);
    }

    private void OnDisable()
    {
        _winningCharacter?.RemoveListener(SetWinner);
    } 

    #endregion

    private void SetTextActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }

    public void SetWinner(string winner)
    {
        _text.text = $"{winner} wins";
        SetTextActive(true);
    }
}
