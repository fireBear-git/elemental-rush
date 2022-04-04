using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _pause;

    [Header("Actions")]
    [SerializeField] private ScriptableAction _onPause;

    private bool _isPaused = false;
    
    private void OnEnable()
    {
        _onPause.AddListener(onPause);
    }

    private void OnDisable()
    {
        _onPause.RemoveListener(onPause);
    }

    private void Update()
    {
        if (_pause.activeInHierarchy != _isPaused)
        {
            _pause.SetActive(_isPaused);
            _main.SetActive(!_isPaused); 
        }
    }

    private void onPause()
    {
        _isPaused = !_isPaused;
    }
}
