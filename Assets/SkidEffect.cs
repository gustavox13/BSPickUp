using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidEffect : MonoBehaviour {
    [SerializeField]
    private Animator skidAnim;
    private string objectTagFloor;
    [SerializeField]
    private bool isOnTheFloor;


    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        skidAnim = GetComponent<Animator>();
        objectTagFloor = Constants.TagName.FLOOR;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectTagFloor)
        {
            isOnTheFloor = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == objectTagFloor)
        {
            isOnTheFloor = false;
        }
    }


    public void Skid()
    {
        if (isOnTheFloor)
        {
            skidAnim.SetTrigger("Acelerate");
        }
    }
}
