using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minY;

    private string objectTag;

    private GameObject objPlayer;

    private void Start()
    {
        objectTag = Constants.TagName.PLAYER;
        objPlayer = GameObject.FindWithTag(objectTag);
    }


    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(objPlayer.transform.position.x, minX, maxX), Mathf.Clamp(objPlayer.transform.position.y, minY, maxY), transform.position.z);
    }
}
