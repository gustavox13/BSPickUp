using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InputUp : MonoBehaviour {
   
        public bool Up
        {
        get { return up; }
        set { up = value; }
        }
        [SerializeField]
        private bool up;

    public static InputUp instance;

    private void Awake()
    {
        up = false;
        if (instance != null)
        {
            Debug.LogError("Multiple instances of GameSave!");
        }
        instance = this;
    }

    private void OnMouseDown()
        {
            up = true;
            Debug.Log("frente pressionada");
        }

    private void OnMouseUp()
        {
            up = false;
            Debug.Log("frente desligada");
        }
}
