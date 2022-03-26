using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesDirector : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _reloadOffset;

    [Header("Actions")]
    [SerializeField] private ScriptableAction _reloadGameScene;
    [SerializeField] private ScriptableAction _gameOver;

    private static bool loaded = false;

    #region Unity Callbacks

    private void Start()
    {
        if (!loaded)
        {
            loaded = true;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        _reloadGameScene?.AddListener(ReloadGameScene);
    }

    private void OnDisable()
    {
        _reloadGameScene?.RemoveListener(ReloadGameScene);
    }

    #endregion

    private IEnumerator ReloadDelay()
    {
        _gameOver?.Invoke();
        yield return new WaitForSeconds(_reloadOffset);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void ReloadGameScene()
    {
        StartCoroutine(ReloadDelay());
    }
}
