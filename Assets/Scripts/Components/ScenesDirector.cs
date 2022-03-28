using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesDirector : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _reloadOffset;

    [Header("Actions")]
    [SerializeField] private ScriptableAction _onDefeat;
    [SerializeField] private ScriptableAction _matchOver;

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
        _onDefeat?.AddListener(MatchOver);
    }

    private void OnDisable()
    {
        _onDefeat?.RemoveListener(MatchOver);
    }

    #endregion

    private IEnumerator ReloadMatch()
    {
        _matchOver?.Invoke();
        yield return new WaitForSeconds(_reloadOffset);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void MatchOver()
    {
        StartCoroutine(ReloadMatch());
    }
}
