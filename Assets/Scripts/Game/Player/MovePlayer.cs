using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    //PROPRIEDADES
    [SerializeField]
    private float speed = 1000;
    [SerializeField]
    private const float rotationSpeed = 400f;
    [SerializeField]
    private WheelJoint2D backWeel;
    [SerializeField]
    private WheelJoint2D frontWeel;
    [SerializeField]
    private Rigidbody2D playerRB;

    private float movement = 0f;
    private float rotation = 0f;



    private void Update()
    {  
        InputController(); 
    }

    private void FixedUpdate()
    {
        Motor();
    }

    private void InputController()
    {
        //movement = -Input.GetAxisRaw("Vertical") * speed;
        //rotation = Input.GetAxisRaw("Horizontal");
       
        if ( InputUp.instance.Up == true)
        {
         
            movement = -1 * speed;
            rotation = 1;
        }
        else if (InputDown.instance.Down == true)
        {
        
            movement = 1 * speed;
            rotation = -1;
        }
        else
        {
            movement = 0;
            rotation = 0;
        }


    }

    

    private void Motor()
    {
        if (movement == 0f)
        {
            backWeel.useMotor = false;
            frontWeel.useMotor = false;
        }
        else
        {
            backWeel.useMotor = true;
            frontWeel.useMotor = true;
             JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWeel.motor.maxMotorTorque};
            
            backWeel.motor = motor;
            frontWeel.motor = motor;
        }

        playerRB.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }
}
