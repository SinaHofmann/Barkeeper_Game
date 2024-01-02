using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{

    //Animation muss gecalled werden
    //T�ren sind offen nur play button, kein return
    // wenn play gedr�ckt wird gehen t�ren zu
    // dann wird gesamtes menu canvas deactiviert
    // wenn auf schrank geklickt wird, wird canvas aktive
    // dann wird paly button deactive und return wird active
    // dann gehen t�ren auf
    // wenn auf return gedr�ckt wird gehen t�ren zu



    input_manager inputManager;

    camera_movement camMovementScript;


    public Transform camPosMenu;

    public Transform mainCameraTransform;

    public Transform camStartPos;

    public GameObject PlayButtonObj;

    public GameObject ReturnButtonObj;

    public GameObject MenuCanvas;


    public float transitionDuration = 1f;

    Vector3 previousCamPosition;
    Quaternion previousCamRotation;


    public void Start()
    {
        inputManager = FindObjectOfType<input_manager>();
        camMovementScript = FindObjectOfType<camera_movement>();

        inputManager.playerControls.player_movement.Disable();
        inputManager.playerControls.menu_movement.Enable();

        camMovementScript.restrictCamMovement = true;
        
    }

    public void PlayButton()
    {
        StartCoroutine(CamToPlayerStartPos(camStartPos.position, camStartPos.rotation));
    }

    public void ReturnToGameButton()
    {

        StartCoroutine(CamToPlayerCurrentPos(previousCamPosition, previousCamRotation));
    }

    public void OpenMenuShelf()
    {

        inputManager.movementInput.x = 0;
        inputManager.movementInput.y = 0;

        inputManager.cameraInput.x = 0;
        inputManager.cameraInput.y = 0;

        inputManager.playerControls.player_movement.Disable();
        inputManager.playerControls.menu_movement.Enable();

        camMovementScript.restrictCamMovement = true;
        //we need to set it to false, if the cam goes back to player

        previousCamPosition = mainCameraTransform.position;
        previousCamRotation = mainCameraTransform.rotation;

      

        StartCoroutine(CamToMenuPos(camPosMenu.position, camPosMenu.rotation));

    }


    IEnumerator CamToPlayerStartPos(Vector3 targetCamPosition, Quaternion targetCamRotation)
    {

        float elapsedTime = 0;


        Vector3 initialCamPosition = mainCameraTransform.position;
        Quaternion initialCamRotation = mainCameraTransform.rotation;


        while (elapsedTime < transitionDuration) //moves cam to specified pos
        {
            mainCameraTransform.position = Vector3.Lerp(initialCamPosition, targetCamPosition, elapsedTime / transitionDuration);

            mainCameraTransform.rotation = Quaternion.Lerp(initialCamRotation, targetCamRotation, elapsedTime / transitionDuration);

            elapsedTime = elapsedTime + Time.deltaTime;

            yield return null;

        }

        //make sure it actually gets to the desired pos/rot
        mainCameraTransform.position = targetCamPosition;

        mainCameraTransform.rotation = targetCamRotation;

        //here we activate player movement


        inputManager.playerControls.menu_movement.Disable();
        inputManager.playerControls.player_movement.Enable();

        camMovementScript.restrictCamMovement = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;




        Debug.Log("uh we startin");

        yield return null;
    }

    IEnumerator CamToPlayerCurrentPos(Vector3 targetCamPosition, Quaternion targetCamRotation)
    {
        float elapsedTime = 0;


        Vector3 initialCamPosition = mainCameraTransform.position;
        Quaternion initialCamRotation = mainCameraTransform.rotation;


        while (elapsedTime < transitionDuration) //moves cam to specified pos
        {
            mainCameraTransform.position = Vector3.Lerp(initialCamPosition, targetCamPosition, elapsedTime / transitionDuration);

            mainCameraTransform.rotation = Quaternion.Lerp(initialCamRotation, targetCamRotation, elapsedTime / transitionDuration);

            elapsedTime = elapsedTime + Time.deltaTime;

            yield return null;

        }

        //make sure it actually gets to the desired pos/rot
        mainCameraTransform.position = targetCamPosition;

        mainCameraTransform.rotation = targetCamRotation;

        //here we activate player movement


        inputManager.playerControls.menu_movement.Disable();
        inputManager.playerControls.player_movement.Enable();
        
        camMovementScript.restrictCamMovement = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



        Debug.Log("weee to the player");

        yield return null;
    }

    IEnumerator CamToMenuPos(Vector3 targetCamPosition, Quaternion targetCamRotation)
    {

        float elapsedTime = 0;
        

        Vector3 initialCamPosition = mainCameraTransform.position;
        Quaternion initialCamRotation = mainCameraTransform.rotation;


        while(elapsedTime < transitionDuration) //moves cam to specified pos
        {
            mainCameraTransform.position = Vector3.Lerp(initialCamPosition, targetCamPosition, elapsedTime / transitionDuration);

            mainCameraTransform.rotation = Quaternion.Lerp(initialCamRotation, targetCamRotation, elapsedTime / transitionDuration);

            elapsedTime = elapsedTime + Time.deltaTime;

            yield return null;

        }

        //make sure it actually gets to the desired pos/rot
        mainCameraTransform.position = targetCamPosition;

        mainCameraTransform.rotation = targetCamRotation;

        //here we deactivate player movement and switch UI movement and turn on cursor

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        Debug.Log("oooho we open");

        yield return null;
    }



}
