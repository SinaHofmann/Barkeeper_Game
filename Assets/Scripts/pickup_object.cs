using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_object : MonoBehaviour
{
    //groﬂ schreiben nur wenn wir etwas neues declaren z.B, ein Transform oder ein Game Object

    input_manager inputManager; //1. actual name of script 2. how you will reference the script in this code
    public Transform holdParent;
    public LayerMask interactableLayer; //lets you select a layer in editor
    public GameObject indicatorDecal; // ground marking
    private GameObject heldObject;
    public float movementForce; //how fast the held Object will be moved while holding
    public float raycastRange;
    public float dragforce;
    public float rotationspeed;

    private void Start()
    {
        inputManager = FindObjectOfType<input_manager>();

    }

    private void FixedUpdate()
    {
        if (inputManager.pickUpInput == true) //did we click on left mouse button?
        {
            if (heldObject == null) //are we holding something? only pickUp objects if we are not already holding something
            {
                RaycastHit hit; //information of hitted object are stored here in "hit"

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastRange, interactableLayer)) //where does the raycast start, which direction, where is the info stored, range, which layer will it register
                {
                    PickUp(hit.transform.gameObject); //this is what is called when the left mouse button is clicked, a raycast is created and pickUp function is called
                }
            }

        }

        if (heldObject != null) //if we are holding something, then we will move object
        {
            MoveObject();

            RaycastHit hitDecal;

            if (Physics.Raycast(heldObject.transform.position, Vector3.down, out hitDecal, Mathf.Infinity, Physics.AllLayers, QueryTriggerInteraction.Ignore)) //ground marking code
            {
                indicatorDecal.SetActive(true);

                indicatorDecal.transform.position = hitDecal.point + new Vector3(0, 0.02f, 0);

                indicatorDecal.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 180));
            }

            if (inputManager.rotateInput == true)
            {
                RotateObject();

                
            }

        } 
        else if (heldObject == null)
        {
            indicatorDecal.SetActive(false);
        }

        


        if (inputManager.pickUpInput == false) //the mouse button is not pressed
        {
            if (heldObject != null) //if we are holding something, we drop it
            {
                DropObject();
            }
        }

        
    }

    void PickUp(GameObject hitObject)
    {
    
        if (hitObject.GetComponent<Rigidbody>()) //if we hold an object, we must disable some rigidbody options
        {
            Rigidbody objRigidbody = hitObject.GetComponent<Rigidbody>();

            objRigidbody.useGravity = false;
            objRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            objRigidbody.drag = dragforce;
            objRigidbody.transform.parent = holdParent; //if this is turned on, movement force is not affected, it will have no drag

            heldObject = hitObject;
        }


    }


    void MoveObject()
    {
        if (Vector3.Distance(heldObject.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = holdParent.position - heldObject.transform.position;

            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection * movementForce * Time.deltaTime); 
        }
    }

    void DropObject()
    {
        if (heldObject.GetComponent<Rigidbody>())
        {
            Rigidbody heldRigidbody = heldObject.GetComponent<Rigidbody>();

            heldRigidbody.useGravity = true;
            heldRigidbody.constraints = RigidbodyConstraints.None;
            heldRigidbody.drag = 0f;
            heldRigidbody.transform.parent = null;

            heldObject = null;

        }
    }

    void RotateObject()
    {
        Debug.Log("weeh spinny");

        heldObject.transform.Rotate(Vector3.right * rotationspeed);
    }


}
