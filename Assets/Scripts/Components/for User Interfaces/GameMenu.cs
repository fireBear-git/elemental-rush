using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject[] _disableOnPause;
    [SerializeField] GameObject[] _disableOnBattleEnd;

    private void OnEnable()
    {
        for(int i = 0; i < _disableOnPause.Length; i++)
		{
            _disableOnPause[i].SetActive(Battle.isOver);
        }

        for (int i = 0; i < _disableOnBattleEnd.Length; i++)
        {
            _disableOnBattleEnd[i].SetActive(!Battle.isOver);
        }
    }

}
