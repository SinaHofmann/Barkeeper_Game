using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jug_manager : MonoBehaviour
{

    public List<int> playersDrinkList = new List<int>(); //make a new list, that list containes the ing that the player throws in the jar
    

    void OnTriggerEnter(Collider other) //what happens if something is thrown in the jar
    {
        if (playersDrinkList.Count < 3)
        {
            if (other.CompareTag("Ing_A"))
            {
                Debug.Log("Ing A in the jug");

                playersDrinkList.Add(1);

                Destroy(other.gameObject);

            }

            if (other.CompareTag("Ing_B"))
            {
                Debug.Log("Ing B in the jug");

                playersDrinkList.Add(2);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_C"))
            {
                Debug.Log("Ing C in the jug");

                playersDrinkList.Add(3);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_D"))
            {
                Debug.Log("Ing D in the jug");

                playersDrinkList.Add(4);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_E"))
            {
                Debug.Log("Ing E in the jug");

                playersDrinkList.Add(5);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_F"))
            {
                Debug.Log("Ing F in the jug");

                playersDrinkList.Add(6);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_G"))
            {
                Debug.Log("Ing G in the jug");

                playersDrinkList.Add(7);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_H"))
            {
                Debug.Log("Ing H in the jug");

                playersDrinkList.Add(8);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_I"))
            {
                Debug.Log("Ing I in the jug");

                playersDrinkList.Add(9);

                Destroy(other.gameObject);
            }

            if (other.CompareTag("Ing_J"))
            {
                Debug.Log("Ing J in the jug");

                playersDrinkList.Add(10);

                Destroy(other.gameObject);
            }
        }


      
    }
}

