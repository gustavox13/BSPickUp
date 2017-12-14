using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitMove : MonoBehaviour {

    private const float REFERENCE_Z_POSITION = 0;
    private const string MIN_LIMIT = "min";
    private const string MAX_LIMIT = "max";

    private float referenceYPosition;
    private float referenceXPosition;
    private float currentPlayerPositionX;
    private float currentPlayerPositionY;
    private float currentPlayerPositionZ;

    private void Update()
    {
        CurrentPositions();

        PlayerLimitOnScreen();
    }

    // Get current points position (x, y, z) of player
    private void CurrentPositions()
    {
        currentPlayerPositionX = transform.position.x;
        currentPlayerPositionY = transform.position.y;
        currentPlayerPositionZ = transform.position.z;
    }

    // Limit player on screen
    private void PlayerLimitOnScreen()
    {
        float limitY = Mathf.Clamp(currentPlayerPositionY, LimitYOnScreenY(MIN_LIMIT),LimitYOnScreenY(MAX_LIMIT));
        float limitX = Mathf.Clamp(currentPlayerPositionX, LimitYOnScreenX(MIN_LIMIT), LimitYOnScreenX(MAX_LIMIT));

        Vector3 limitVector = new Vector3(limitX,limitY,currentPlayerPositionZ);

        transform.position = limitVector;
    }

    // Limit Y position to screen
    private float LimitYOnScreenY(string typeOfLimit)
    {
        SelectReferenceYPosition(typeOfLimit);
        SelectReferenceXPosition(typeOfLimit);

        Vector3 referencePoints = new Vector3(referenceXPosition,referenceYPosition,REFERENCE_Z_POSITION);

        float limitY = Camera.main.ViewportToWorldPoint(referencePoints).y;
        float limitX = Camera.main.ViewportToWorldPoint(referencePoints).x;

        return limitY;
    }

    // Limit Y position to screen
    private float LimitYOnScreenX(string typeOfLimit)
    {
        SelectReferenceYPosition(typeOfLimit);
        SelectReferenceXPosition(typeOfLimit);

        Vector3 referencePoints = new Vector3(referenceXPosition, referenceYPosition, REFERENCE_Z_POSITION);

        float limitY = Camera.main.ViewportToWorldPoint(referencePoints).y;
        float limitX = Camera.main.ViewportToWorldPoint(referencePoints).x;

        return limitX;
    }

    // Select Reference Y position
    private float SelectReferenceYPosition(string typeOfLimit)
    {
        if (typeOfLimit == MIN_LIMIT)
        {
            referenceYPosition = 0;
        }
        else
        {
            referenceYPosition = 1;
        }

        return referenceYPosition;
    }

    private float SelectReferenceXPosition(string typeOfLimit)
    {
        if (typeOfLimit == MIN_LIMIT)
        {
            referenceXPosition = 0;
        }
        else
        {
            referenceXPosition = 1;
        }

        return referenceXPosition;
    }

}
