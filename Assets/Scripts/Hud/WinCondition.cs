using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour {

    [SerializeField]
    private Canvas WinScreen;
    [SerializeField]
    private string objectTag;
    [SerializeField]
    private float WinPosition;
    private GameObject objPlayer;
    [SerializeField]
    private Win WinScript;

    private void Start () {
        LoadResources();
    }

    private void LoadResources()
    {
        Time.timeScale = 1.0f;
        WinScreen.enabled = false;
        objPlayer = GameObject.FindWithTag(objectTag);
    }

    private void Update () {
        Condition();
    }

    private void Condition()
    {
        if (objPlayer.transform.position.y <= WinPosition) // altera para x depois 
        {
            WinGame();
        }
    }


    private void WinGame()
    {
        Time.timeScale = 0.0f;
        WinScript.UnlockNextLevel();
        WinScreen.enabled = true;
    }

}
