using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private Text _text;

    [Header("Scriptables Actions")]
    [SerializeField] private ScriptableAction _onHit;

    private GameObject _textGO => _text.gameObject;

    private float _maxComboOffset = 2.5f;
    private float _actualComboOffset;

    private int _combo;


    private void Start()
    {
        _actualComboOffset = 0f;
    }

    private void OnEnable()
    {
        _onHit.AddListener(AddCombo);
    }

    private void OnDisable()
    {
        _onHit.RemoveListener(AddCombo);
    }
    private void Update()
    {
        if(_actualComboOffset > 0f)
            _actualComboOffset -= Time.deltaTime;
        
        if(_actualComboOffset <= 0)
        {
            _combo = 0;
            _textGO.SetActive(false);
        }
    }

    public void AddCombo()
    {
        _actualComboOffset = _maxComboOffset;
        _combo++;
        
        _text.text = $"Combo: {_combo}";

        if (_combo >= 3 && !_text.gameObject.activeInHierarchy)
            _textGO.SetActive(true);
    }
}
