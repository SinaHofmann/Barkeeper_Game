using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class guest_manager : MonoBehaviour
{
    public List<int> guestsDrinkList = new List<int>(); //make a new list, that list containes the ing that the guest randomly chooses

    public List<Image> ingPicGuestList = new List<Image>(); //Ing pictures in guest speechbubble that were put in jug

    public List<Image> feedbackColoursGuestList = new List<Image>(); //coloured feedback in guest speechbubble

    jug_manager jugManager; //1. actual name of script 2. how you will reference the script in this code

    private bool comparingStartet;

    public GameObject speechbubble;

    public Sprite correct;
    public Sprite almost;
    public Sprite wrong;

    public Color green;
    public Color yellow;
    public Color red;

    public int roundCounter = 1;



    private List<List<Image>> motherList = new List<List<Image>>(); //mother list that containes 5 lists, 1 for each round

    public List<Image> round1List = new List<Image>(); //list for the Img Pics that will be displayed on the board, what ing we put in the jug
    public List<Image> round2List = new List<Image>();
    public List<Image> round3List = new List<Image>();
    public List<Image> round4List = new List<Image>();
    public List<Image> round5List = new List<Image>();

    public List<Image> concatList = new List<Image>();



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


        motherList.Add(round1List);
        motherList.Add(round2List);
        motherList.Add(round3List);
        motherList.Add(round4List);
        motherList.Add(round5List);



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
                
                ingPicGuestList[i].gameObject.SetActive(true);

                //guestFeedbackImagesList[i].color = green;


                feedbackColoursGuestList[i].gameObject.SetActive(true);

                feedbackColoursGuestList[i].color = green;

                feedbackColoursGuestList[i].sprite = correct;


                //Debug.Log("green");

            }
            else if(jugManager.playersDrinkList[i] != guestsDrinkList[i])
            {
                //if its not the same number in the slot, but the number is anywhere in the list
                if (guestsDrinkList.Contains(jugManager.playersDrinkList[i]))
                {
                    
                    ingPicGuestList[i].gameObject.SetActive(true);

                    //guestFeedbackImagesList[i].color = yellow;


                    feedbackColoursGuestList[i].gameObject.SetActive(true);

                    feedbackColoursGuestList[i].color = yellow;

                    feedbackColoursGuestList[i].sprite = almost;

                    //Debug.Log("yellow");
                }
                //if there is no match for the number
                else if (!guestsDrinkList.Contains(jugManager.playersDrinkList[i]))
                {
                    ingPicGuestList[i].gameObject.SetActive(true);

                    //guestFeedbackImagesList[i].color = red;


                    feedbackColoursGuestList[i].gameObject.SetActive(true);

                    feedbackColoursGuestList[i].color = red;

                    feedbackColoursGuestList[i].sprite = wrong;

                    //Debug.Log("red");
                }
                
               
            }

                
        }

        int greenSlot = 0;

        for (int i = 0; i < 3; i++) //winnig condition
        {
            if (feedbackColoursGuestList[i].color == green)
            {
                greenSlot++;
            }

        }

        if (greenSlot == 3)
        {
            Debug.Log("You won!");

            //bool "game has ended" muss auf true und das ist der faktor das der nächste gast kommt
        }
        else if (greenSlot != 3 && roundCounter < 5)
        {

            Debug.Log("Next round");

            StartCoroutine(NextRoundTimer());

        }
        else if (greenSlot != 3 && roundCounter == 5)
        {
            Debug.Log("You lost!");

            //bool "game has ended" muss auf true und das ist der faktor das der nächste gast kommt
        }


    }


    IEnumerator NextRoundTimer()
    {


        yield return new WaitForSeconds(3);

        Debug.Log("We waited 3 sec");


        concatList = ingPicGuestList.Concat(feedbackColoursGuestList).ToList(); //inf Pics and Ing feedback will be added to one list

        for (int i = 0; i < concatList.Count; i++)
        {
            motherList[roundCounter - 1][i].sprite = concatList[i].sprite; //we look at number of rounds and the corresponding List in the motherlist, then take the sprite components of the Images in th Speechbubble and put them in the corresponding list under the motherlist

            motherList[roundCounter - 1][i].color = concatList[i].color;

            motherList[roundCounter - 1][i].gameObject.SetActive(true);
        }




        // content of speechbubble appears on board 

        //rundencounter int, zählt pro runde hoch, überliste[rundsecounter], loop listenlänge, concat 2 listen der speechbubble in eine, setzten von dieser liste 1 auf überliste[rundsecounter][1] etc.


        // speechbubble wipe
        // jug wipe
        // ing new spawn

        roundCounter++;

        yield return null;
    }
}
