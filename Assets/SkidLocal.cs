using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidLocal : MonoBehaviour {

    private string objectTagPlayer;
    private GameObject objPlayer;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        objectTagPlayer = Constants.TagName.PLAYER;
        objPlayer = GameObject.FindWithTag(objectTagPlayer);
    }

    private void Update()
    {

        gameObject.transform.position = new Vector3(objPlayer.transform.position.x,
                                                    objPlayer.transform.position.y,
                                                    objPlayer.transform.position.z);
    }
}
