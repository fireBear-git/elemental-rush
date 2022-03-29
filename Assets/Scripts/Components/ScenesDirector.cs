using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesDirector : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _reloadOffset;

    [Header("Actions")]
    [SerializeField] private ScriptableAction _reloadMatch;

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
        _reloadMatch?.AddListener(reloadMatch);
    }

    private void OnDisable()
    {
        _reloadMatch?.RemoveListener(reloadMatch);
    }

    #endregion

    private IEnumerator reloadSceneAfterSeconds()
    {
        yield return new WaitForSeconds(_reloadOffset);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void reloadMatch()
    {
        StartCoroutine(reloadSceneAfterSeconds());
    }
}
