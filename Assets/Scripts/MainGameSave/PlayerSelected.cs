using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelected : MonoBehaviour {

    //yellow = 0 angle    =  1
    //blue   = 90 angle   =  2
    //green  = 180 angle  =  3
    //red    = 270 angle  =  4

    public int NumberPlayerSelected
        {
            get { return numberPlayerSelected; }
            set { numberPlayerSelected = value; }
        }
    private int numberPlayerSelected;

    private int yellow = 0;
    private int blue = 1;
    private int green = 2;
    private int red = 3;

    public static PlayerSelected instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple instances of GameSave!");
        }
        instance = this;
    }


    public void ConvertPlayerTypeToInt(float PlayerFloatValue)
    {
        if ((int)PlayerFloatValue == 0)
        {
            numberPlayerSelected = yellow;
        } else if ((int)PlayerFloatValue == 90)
        {
            numberPlayerSelected = blue;
        } else if ((int)PlayerFloatValue == 180)
        {
            numberPlayerSelected = green;
        }
        else
        {
            numberPlayerSelected = red;
        }
    }

    
    public void SelectRedCar()
    {
        numberPlayerSelected = red;
    }
}
