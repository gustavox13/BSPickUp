﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    [SerializeField]
    private StarCount starCountScript;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Constants.TagName.PLAYER)
        {
            AddStar();
            gameObject.SetActive(false);
        }
    }

    private void AddStar()
    {
        starCountScript.NumberStars++;
    }

}
