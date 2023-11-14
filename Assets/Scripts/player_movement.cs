using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{

    input_manager inputManager;
    CharacterController charController;

    [Header("Inputs and Velocities")]
    public float horizontalInput;
    public float verticalInput;
    [Space (10)]

    public Vector3 lastVelocity;
    public Vector3 movement;

    public float speed = 0f;
    public float acceleration = 9f;
    public float maxspeed = 3.6f;
    public float stoppingforce = 18f;



    private void Awake()
    {
        inputManager = GetComponent<input_manager>();
        charController = GetComponent<CharacterController>();
    }


    public void GetPlayerInput()
    {
        horizontalInput = inputManager.movementInput.x;
        verticalInput = inputManager.movementInput.y;
    }


    private void Update()
    {
        GetPlayerInput();

        if (horizontalInput != 0 || verticalInput != 0)
        {
            lastVelocity = movement;
        }

        movement = Vector3.Normalize((transform.right * horizontalInput) + (transform.forward * verticalInput));





        //acceleration 

        if (movement.sqrMagnitude > 0)
        {
            if (speed < maxspeed)
            {
                speed = speed + acceleration * Time.deltaTime;
            }
        }
        else if (movement.sqrMagnitude == 0)
        {
            speed = speed - stoppingforce * Time.deltaTime;
            movement = lastVelocity / 5;

            if (speed <= 0)
            {
                speed = 0;
                movement = Vector3.zero;  // (0,0,0)
                lastVelocity = Vector3.zero;
            }
        }
 



        //actual movement

        charController.Move((movement * speed) * Time.deltaTime);


        //gravity declared

        if (charController.isGrounded == false)
        {
            charController.Move(new Vector3(0, -0.15f, 0));
        }


        if (Input.GetKeyDown("r"))
        {
            Reset();
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
