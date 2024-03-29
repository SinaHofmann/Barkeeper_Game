using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script references the Player Controls Input Action Assets and the script so it can be used in other scripts

public class input_manager : MonoBehaviour
{
    public Player_Controls playerControls;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    public bool pickUpInput;
    public bool serveDrinkInput;
    public bool reloadSceneInput;

    public bool rotateInput;


    private void OnEnable()
    {

        if (playerControls == null)
        {
            playerControls = new Player_Controls();

            playerControls.player_movement.movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.player_movement.camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.player_movement.pickup.started += i => pickUpInput = true;
            playerControls.player_movement.pickup.canceled += i => pickUpInput = false;

            playerControls.player_movement.rotate.started += i => rotateInput = true;
            playerControls.player_movement.rotate.canceled += i => rotateInput = false;

            playerControls.player_movement.ServeDrink.started += i => serveDrinkInput = true;
            playerControls.player_movement.ServeDrink.canceled += i => serveDrinkInput = false;

            playerControls.player_movement.ReloadScene.started += i => reloadSceneInput = true;
            playerControls.player_movement.ReloadScene.canceled += i => reloadSceneInput = false;


        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();

    }

}
