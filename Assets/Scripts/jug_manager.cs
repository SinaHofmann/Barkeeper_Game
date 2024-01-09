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

    public ParticleSystem splashEffect;

    public AudioSource splashSound;

   // public GameObject ServePrompt;


    private void Start()
    {
        inputManager = FindObjectOfType<input_manager>();

        guestManager = FindObjectOfType<guest_manager>();
    }


    void OnTriggerEnter(Collider other) //what happens if something is thrown in the jar
    {
        

        if (playersDrinkList.Count < 3)
        {
            guestManager.SpeechBubbleImages(other.gameObject);
        }

       

        splashEffect.Play();


        float randomNumber = Random.Range(0.7f, 1.3f);

        splashSound.pitch = randomNumber;

        splashSound.Play();


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

        /*
        if (ServePrompt.activeInHierarchy == false)
        {
            ServePrompt.SetActive(true);

        }
        */

        if (inputManager.serveDrinkInput) //if F is pressed, Ui element will turn off and drink served is true
        {
            inputManager.serveDrinkInput = false; //this way the input will only be called once and not continuesly

            drinkServed = true;

            //ServePrompt.SetActive(false);

            Debug.Log("Drink was served");
        }

        
    }
}

