using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jug_manager : MonoBehaviour
{
    input_manager inputManager;

    public List<int> playersDrinkList = new List<int>(); //make a new list, that list containes the ing that the player throws in the jar

    public List<Image> ingPicsList = new List<Image>(); //list for the Img Pics that will be displayed in the scene, what ing we put in the jug

    public bool drinkServed = false;

    public GameObject ServePrompt;


    private void Start()
    {
        inputManager = FindObjectOfType<input_manager>();
    }


    void OnTriggerEnter(Collider other) //what happens if something is thrown in the jar
    {
        if (playersDrinkList.Count < 3)
        {
            if (other.CompareTag("Ing_A"))
            {
                Debug.Log("Ing A in the jug");

                playersDrinkList.Add(1);


                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage; 
                //we go to the ingPicList, to decide what entry we want, we get the entry from the playerDrinkList. So we always have the same entry on both lists. The we declare that in the entry 
                //in the ingPicList will be filled with the Image that is on the Ing Mesh that was thrown in the jug

                Destroy(other.gameObject);

            }

            if (other.CompareTag("Ing_B"))
            {
                Debug.Log("Ing B in the jug");

                playersDrinkList.Add(2);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_C"))
            {
                Debug.Log("Ing C in the jug");

                playersDrinkList.Add(3);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_D"))
            {
                Debug.Log("Ing D in the jug");

                playersDrinkList.Add(4);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_E"))
            {
                Debug.Log("Ing E in the jug");

                playersDrinkList.Add(5);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_F"))
            {
                Debug.Log("Ing F in the jug");

                playersDrinkList.Add(6);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_G"))
            {
                Debug.Log("Ing G in the jug");

                playersDrinkList.Add(7);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_H"))
            {
                Debug.Log("Ing H in the jug");

                playersDrinkList.Add(8);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_I"))
            {
                Debug.Log("Ing I in the jug");

                playersDrinkList.Add(9);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_J"))
            {
                Debug.Log("Ing J in the jug");

                playersDrinkList.Add(10);

                ingPicsList[playersDrinkList.Count - 1].sprite = other.gameObject.GetComponent<ing_images>().IngImage;

                Destroy(other.gameObject);
            }
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

