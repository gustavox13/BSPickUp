﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour {

    
    private string objectTag;

    public bool PlayerDied
    {
        get { return playerDied; }
        set { playerDied = value; }
    }
    private bool playerDied;

    private void Start()
    {
        LoadResources();
    }


    private void LoadResources()
    {
        playerDied = false;
        objectTag = Constants.TagName.FLOOR;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            playerDied = true;
        }
    }
}
