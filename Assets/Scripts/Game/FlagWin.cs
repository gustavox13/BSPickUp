using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagWin : MonoBehaviour {

    [SerializeField]
    private AudioSource winSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Constants.TagName.PLAYER)
        {
            EnableSound();
           
        }
    }



    private void EnableSound()
    {
        winSound.Play();
    }
}
