using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Image _specialAttacksBar;

    [Header("Scriptables Dipendencies")]
    [SerializeField] private ScriptableActionFloat _updateHealthAction;
        
    private void OnEnable()
    {
        _updateHealthAction?.AddListener(UpdateLife);
    }

    private void OnDisable()
    {
        _updateHealthAction?.RemoveListener(UpdateLife);
    }

    public void UpdateLife(float amount)
    {
        _lifeBar.fillAmount = amount;
    }

    public void UpdateSpecial(float amount)
    {
        _specialAttacksBar.fillAmount = amount;
    }
}
