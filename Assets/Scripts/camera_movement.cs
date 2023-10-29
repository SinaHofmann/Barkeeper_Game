using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    input_manager inputManager;
    public Transform playerBody;

    public float mouseSensitivity = 0.1f;

    private float xRotation = 0f;

    private void Awake()
    {
        inputManager = FindObjectOfType<input_manager>();

        Cursor.lockState = CursorLockMode.Locked; //cursor is always screen center
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        float mouseX = inputManager.cameraInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = inputManager.cameraInput.y * mouseSensitivity * Time.deltaTime;


        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);


    }

}
