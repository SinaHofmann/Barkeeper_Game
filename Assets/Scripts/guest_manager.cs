using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guest_manager : MonoBehaviour
{
    public List<int> guestsDrinkList = new List<int>(); //make a new list, that list containes the ing that the guest randomly chooses

    public List<Image> guestFeedbackImagesList = new List<Image>(); //new list for the visuall guest feedback

    public List<Image> guestFeedbackColoursList = new List<Image>(); //new list for colour feedback on the player tries board

    jug_manager jugManager; //1. actual name of script 2. how you will reference the script in this code

    private bool comparingStartet;

    public GameObject speechbubble;

    public Color green;
    public Color yellow;
    public Color red;


    private void Start()
    {

        jugManager = FindObjectOfType<jug_manager>();



        for (int i = 0; i < 3; i++) //loop repeats its content 3 times
        {
            int numberToAdd = Random.Range(1, 11); //it generates a number between 1 and 10 and adds that to list

            while (guestsDrinkList.Contains(numberToAdd)) //while the list contains a number twice, the number is generated new until it differs
            {
                numberToAdd = Random.Range(1, 11);
            }

            
            guestsDrinkList.Add(numberToAdd);
        }


    }

    private void Update()
    {
        

        if (comparingStartet == false)
        {
            if (jugManager.drinkServed == true)
            {
                CompareLists();
            }
        }
        
    }

    //wir prüfen, ob der spieler das getränk serviert hat. Dann müssen playersDrinkList und guestsDrinkList verglichen werden
    void CompareLists()
    {
        comparingStartet = true;

        speechbubble.SetActive(true);

        for (int i = 0; i < 3; i++) //loop repeats its content 3 times
        {
            //if both slots are identical
            if (jugManager.playersDrinkList[i] == guestsDrinkList[i]) //i will always get you the slot in the list, that the loop is currently at
            {
                
                guestFeedbackImagesList[i].gameObject.SetActive(true);

                guestFeedbackImagesList[i].color = green;


                guestFeedbackColoursList[i].gameObject.SetActive(true);

                guestFeedbackColoursList[i].color = green;


                Debug.Log("green");

            }
            else if(jugManager.playersDrinkList[i] != guestsDrinkList[i])
            {
                //if its not the same number in the slot, but the number is anywhere in the list
                if (guestsDrinkList.Contains(jugManager.playersDrinkList[i]))
                {
                    
                    guestFeedbackImagesList[i].gameObject.SetActive(true);

                    guestFeedbackImagesList[i].color = yellow;


                    guestFeedbackColoursList[i].gameObject.SetActive(true);

                    guestFeedbackColoursList[i].color = yellow;

                    Debug.Log("yellow");
                }
                //if there is no match for the number
                else if (!guestsDrinkList.Contains(jugManager.playersDrinkList[i]))
                {
                    guestFeedbackImagesList[i].gameObject.SetActive(true);

                    guestFeedbackImagesList[i].color = red;


                    guestFeedbackColoursList[i].gameObject.SetActive(true);

                    guestFeedbackColoursList[i].color = red;

                    Debug.Log("red");
                }
                
               
            }

                
        }
    }
}
