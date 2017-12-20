using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SelectPlayer : MonoBehaviour {
    [SerializeField]
    private AudioSource soundSwipe;

    [SerializeField]
    private GameObject showCase;

    private Vector2 firstPressPos;

    private bool verifySwipe = false;

    private void Start()
    {
        PlayerSelected.instance.ConvertPlayerTypeToInt(showCase.transform.eulerAngles.y);
    }


    private void Update()
    {
        WhenInputTouch();
    }

    private void WhenInputTouch()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                var secondPressPos = new Vector2(t.position.x, t.position.y);
                var currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();

                //SWIPE LEFT
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    SwipeLeft();
                }
                //SWIPE RIGHT
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    SwipeRight();
                }
            }
        }
    }


    private void SwipeLeft()
    {
        soundSwipe.Play();
        verifySwipe = true;
        Move(90);
        PlayerSelected.instance.ConvertPlayerTypeToInt(showCase.transform.eulerAngles.y);
    }

    private void SwipeRight()
    {
        soundSwipe.Play();
        verifySwipe = true;
        Move(-90);
        PlayerSelected.instance.ConvertPlayerTypeToInt(showCase.transform.eulerAngles.y);
    }

private void Move(int angRotation)
    {
        showCase.transform.eulerAngles = new Vector3(0, showCase.transform.eulerAngles.y + angRotation, 0);
        verifySwipe = false;
    }
}
