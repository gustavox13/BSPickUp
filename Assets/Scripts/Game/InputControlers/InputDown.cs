using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDown : MonoBehaviour {

    public bool Down
    {
        get { return down; }
        set { down = value; }
    }
    [SerializeField]
    private bool down;

    public static InputDown instance;

    private void Awake()
    {
        down = false;
        if (instance != null)
        {
            Debug.LogError("Multiple instances of GameSave!");
        }
        instance = this;
    }



        private void OnMouseDown()
    {
        down = true;
        Debug.Log("ré pressionada");
    }

    private void OnMouseUp()
    {
        down = false;
        Debug.Log("ré desligada");
    }
}
