using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guest_manager : MonoBehaviour
{
    public List<int> guestsDrinkList = new List<int>(); //make a new list, that list containes the ing that the guest randomly chooses

    jug_manager jugManager; //1. actual name of script 2. how you will reference the script in this code



    private void Start()
    {

        jugManager = FindObjectOfType<jug_manager>();



        for (int i = 0; i < 3; i++) //loop repeats its content 3 times
        {
            int numberToAdd = Random.Range(1, 11); //it generates a number between 1 and 10 and adds that to list

            guestsDrinkList.Add(numberToAdd);
        }


    }

    private void Update()
    {
        //wir pr�fen, ob der spieler das getr�nk serviert hat. Dann m�ssen playersDrinkList und guestsDrinkList verglichen werden

        if (jugManager.drinkServed == true)
        {

        }
    }
}
