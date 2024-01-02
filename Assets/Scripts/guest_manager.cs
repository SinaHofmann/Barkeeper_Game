using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class guest_manager : MonoBehaviour
{
    
    [Header("Drink List and Feedback")]
    [Space(10)]

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

    public int TryCounter = 1;

    [Space(30)]
    [Header("Guest Prefabs")]
    [Space(10)]

    public List<GameObject> guestPrefabsList = new List<GameObject>();

    private GameObject currentGuest;

    

    private List<List<Image>> motherList = new List<List<Image>>(); //mother list that containes 5 lists, 1 for each round

    [Space(30)]
    [Header("Display on Board")]
    [Space(10)]

    public List<Image> round1List = new List<Image>(); //list for the Img Pics that will be displayed on the board, what ing we put in the jug
    public List<Image> round2List = new List<Image>();
    public List<Image> round3List = new List<Image>();
    public List<Image> round4List = new List<Image>();
    public List<Image> round5List = new List<Image>();

    public List<Image> concatList = new List<Image>();

    [Space(30)]
    [Header("Respawn Ing")]
    [Space(10)]

    public GameObject ingA;
    public GameObject ingB;
    public GameObject ingC;
    public GameObject ingD;
    public GameObject ingE;
    public GameObject ingF;
    public GameObject ingG;
    public GameObject ingH;
    public GameObject ingI;
    public GameObject ingJ;

    public Transform spawnPointA;
    public Transform spawnPointB;
    public Transform spawnPointC;
    public Transform spawnPointD;
    public Transform spawnPointE;
    public Transform spawnPointF;
    public Transform spawnPointG;
    public Transform spawnPointH;
    public Transform spawnPointI;
    public Transform spawnPointJ;



    


    private void Start()
    {
        

        jugManager = FindObjectOfType<jug_manager>();

        FirstGuest();

    
    }

    void GenerateNewCombi()
    {
        // wipe the guest list
        guestsDrinkList.Clear();

        //wipe the speech bubble

        for (int i = 0; i < 3; i++)
        {

            ingPicGuestList[i].gameObject.SetActive(false);

            feedbackColoursGuestList[i].gameObject.SetActive(false);

        }

        //wipe board

        for (int i = 0; i < motherList.Count; i++)
        {
            for (int ii = 0; ii < 6; ii++)
            {
                motherList[i][ii].gameObject.SetActive(false);
            }
        }


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

    //wir prüfen, ob der spieler das getränk serviert hat. Dann müssen playersDrinkList und guestsDrinkList verglichen werden, hier wird das Feedback erzeugt
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

            StartCoroutine(StartNewRound());

        }
        else if (greenSlot != 3 && TryCounter < 5)
        {

            Debug.Log("Next try");

            StartCoroutine(NextTryTimer());

        }
        else if (greenSlot != 3 && TryCounter == 5)
        {
            Debug.Log("You lost!");

            StartCoroutine(StartNewRound());

           
        }


    }

    public void SpeechBubbleImages(GameObject ingInJug)
    {
        jugManager.playersDrinkList.Add(ingInJug.GetComponent<ing_images>().id);

        ingPicGuestList[jugManager.playersDrinkList.Count - 1].gameObject.SetActive(true);

        ingPicGuestList[jugManager.playersDrinkList.Count - 1].sprite = ingInJug.GetComponent<ing_images>().IngImage;
        //we go to the ingPicList, to decide what entry we want, we get the entry from the playerDrinkList. So we always have the same entry on both lists. The we declare that in the entry 
        //in the ingPicList will be filled with the Image that is on the Ing Mesh that was thrown in the jug

        Destroy(ingInJug);
    }


    IEnumerator NextTryTimer()
    {


        // content of speechbubble appears on board 

        concatList = ingPicGuestList.Concat(feedbackColoursGuestList).ToList(); //ing Pics and Ing feedback will be added to one list

        for (int i = 0; i < concatList.Count; i++)
        {
            motherList[TryCounter - 1][i].sprite = concatList[i].sprite; //we look at number of rounds and the corresponding List in the motherlist, then take the sprite components of the Images in th Speechbubble and put them in the corresponding list under the motherlist

            motherList[TryCounter - 1][i].color = concatList[i].color;

            motherList[TryCounter - 1][i].gameObject.SetActive(true);
        }


        yield return new WaitForSeconds(2);

        Debug.Log("We waited 2 sec");


        // speechbubble wipe

        for (int i = 0; i < 3; i++)
        {

            ingPicGuestList[i].gameObject.SetActive(false);

            feedbackColoursGuestList[i].gameObject.SetActive(false);

        }

        // jug wipe

        jugManager.playersDrinkList.Clear();

        jugManager.drinkServed = false;

        comparingStartet = false;



        // ing new spawn, destroy all ing and respawn new ones

        DestroyIng();

        Instantiate(ingA, spawnPointA.position, Quaternion.identity);
        Instantiate(ingB, spawnPointB.position, Quaternion.identity);
        Instantiate(ingC, spawnPointC.position, Quaternion.identity);
        Instantiate(ingD, spawnPointD.position, Quaternion.identity);
        Instantiate(ingE, spawnPointE.position, Quaternion.identity);
        Instantiate(ingF, spawnPointF.position, Quaternion.identity);
        Instantiate(ingG, spawnPointG.position, Quaternion.Euler(0, 180, 0));
        Instantiate(ingH, spawnPointH.position, Quaternion.identity);
        Instantiate(ingI, spawnPointI.position, Quaternion.identity);
        Instantiate(ingJ, spawnPointJ.position, Quaternion.Euler(0, 180, 0));


        TryCounter++;

        yield return null;
    }


    void DestroyIng()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Ing");

        foreach (GameObject go in foundObjects)
        {
            Destroy(go);
        }


    }

    //guest spawning part

    IEnumerator StartNewRound()
    {
        //guest despawn animation goes here

        yield return new WaitForSeconds(3);

        Destroy(currentGuest.gameObject);


        int randomGuest = Random.Range(0, 6);

        GameObject instantiatedGuest = Instantiate(guestPrefabsList[randomGuest].gameObject);

        currentGuest = instantiatedGuest;

        GenerateNewCombi();



        // jug wipe

        jugManager.playersDrinkList.Clear();

        jugManager.drinkServed = false;

        comparingStartet = false;

        // ing new spawn, destroy all ing and respawn new ones

        DestroyIng();

        Instantiate(ingA, spawnPointA.position, Quaternion.identity);
        Instantiate(ingB, spawnPointB.position, Quaternion.identity);
        Instantiate(ingC, spawnPointC.position, Quaternion.identity);
        Instantiate(ingD, spawnPointD.position, Quaternion.identity);
        Instantiate(ingE, spawnPointE.position, Quaternion.identity);
        Instantiate(ingF, spawnPointF.position, Quaternion.identity);
        Instantiate(ingG, spawnPointG.position, Quaternion.identity);
        Instantiate(ingH, spawnPointH.position, Quaternion.identity);
        Instantiate(ingI, spawnPointI.position, Quaternion.identity);
        Instantiate(ingJ, spawnPointJ.position, Quaternion.identity);


        TryCounter = 1;



        yield return null;

    }

    void FirstGuest()
    {
        int randomGuest = Random.Range(0, 6);

        GameObject instantiatedGuest = Instantiate(guestPrefabsList[randomGuest].gameObject);

        currentGuest = instantiatedGuest;

        

        GenerateNewCombi();
    }




}
