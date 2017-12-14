using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour {

    [SerializeField]
    private int PlayerListRange = 4;

    [SerializeField]
    private GameObject[] playerList = new GameObject[4];

   

    private void Awake()
    {
        DesactivePlayers();
        ActiveCurrentPlayer();

        
    }

    private void DesactivePlayers()
    {
        for (int i = 0; i < PlayerListRange; i++)
        {
                playerList[i].SetActive(false);
        }
    }

    private void ActiveCurrentPlayer()
    {
          playerList[PlayerSelected.instance.NumberPlayerSelected].SetActive(true);
    }
}
