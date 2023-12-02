using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jug_manager : MonoBehaviour
{
    input_manager inputManager;

    public List<int> playersDrinkList = new List<int>(); //make a new list, that list containes the ing that the player throws in the jar

    //public List<Image> ingPicsBoardList = new List<Image>(); //list for the Img Pics that will be displayed on the board, what ing we put in the jug

    guest_manager guestManager;

    public bool drinkServed = false;

    public GameObject ServePrompt;


    private void Start()
    {
        inputManager = FindObjectOfType<input_manager>();

        guestManager = FindObjectOfType<guest_manager>();
    }


    void OnTriggerEnter(Collider other) //what happens if something is thrown in the jar
    {
        if (playersDrinkList.Count < 3)
        {
            playersDrinkList.Add(other.gameObject.GetComponent<ing_images>().id);

            guestManager.ingPicGuestList[playersDrinkList.Count - 1].gameObject.SetActive(true);

            guestManager.ingPicGuestList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;
            //we go to the ingPicList, to decide what entry we want, we get the entry from the playerDrinkList. So we always have the same entry on both lists. The we declare that in the entry 
            //in the ingPicList will be filled with the Image that is on the Ing Mesh that was thrown in the jug

            Destroy(other.gameObject);
        }
          
    }

    void Update()
    {
        //if playersDrinklist has 3 entrys and we did not already serve a drink: void "serve drink" is called

        if (playersDrinkList.Count == 3 && drinkServed == false)
        {
            ServeDrink();
               
        }
      
    }

    void ServeDrink()
    {
        //if the UI element is off it will be turned on

        if (ServePrompt.activeInHierarchy == false)
        {
            ServePrompt.SetActive(true);

        }

        if (inputManager.serveDrinkInput) //if F is pressed, Ui element will turn off and drink served is true
        {
            inputManager.serveDrinkInput = false; //this way the input will only be called once and not continuesly

            drinkServed = true;

            ServePrompt.SetActive(false);

            Debug.Log("Drink was served");
        }

        
    }
}

