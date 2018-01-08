using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

    [SerializeField]
    private AudioSource som;
    private const float acceleration = 0.01f;
    private const float MAX_PITCH = 1.8f;
    private const float MIN_PITCH = 1f;

    [SerializeField]
    private AudioSource starSound;

    public GameObject MoveFront
    {
        get { return moveFront; }
        set { moveFront = value; }
    }
    [SerializeField]
    private GameObject moveFront;

    public GameObject MoveBack
    {
        get { return moveBack; }
        set { moveBack = value; }
    }
    [SerializeField]
    private GameObject moveBack;


    private ButtonConstantInput componentFront;
    private ButtonConstantInput componentBack;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        componentFront = moveFront.GetComponent<ButtonConstantInput>();
        componentBack = moveBack.GetComponent<ButtonConstantInput>();
    }



    private void Update()
    {
        MotorSound();
        StopSong();
    }

    private void MotorSound()
    {
        if ((Input.GetAxisRaw("Vertical") != 0 || componentFront.Input == 1 || componentBack.Input == 1) && som.pitch < MAX_PITCH)
        {
            som.pitch = som.pitch + acceleration;
        }
        else if (som.pitch > MIN_PITCH)
        {
            som.pitch = som.pitch - acceleration;
        }
    }


    private void StopSong()
    {
        if (Time.timeScale == 0.0f)
        {
            som.Stop();
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == Constants.TagName.STAR)
        {
            starSound.Play();
        }
    }
}
