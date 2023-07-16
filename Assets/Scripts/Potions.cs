using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour
{


    //if player collides with potion then we heal the player using player health class


    //public PlayerHealth TeraPlayerhealth;
    //public PlayerHealth KevPlayerhealth;


   public int purplePotionHeal;

    // Start is called before the first frame update
   void Start()
   {
        purplePotionHeal = 5;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {  
        //Debug.Log("i collide"+ name);
        if (collision.gameObject.CompareTag("Tera"))
        {
            //Debug.Log("i collide with tera")

       
            
            if (gameObject.CompareTag("purple potion"))
            {

                // Debug.Log("i do heal");

                //add to inventory, destroy game object, add prefab image of item
                //in the available slot and when player presses the key then heal 

                collision.GetComponent<PlayerHealth>().HealPlayer(purplePotionHeal);
              // 
               
               Destroy(gameObject);
              //
           }
           }
        if (collision.gameObject.CompareTag("Kev"))
        {
            //Debug.Log("i collide with tera")



            if (gameObject.CompareTag("purple potion"))
            {

                // Debug.Log("i do heal");

                //add to inventory, destroy game object, add prefab image of item
                //in the available slot and when player presses the key then heal 

                //playerhealth.HealPlayer(potionHeal);
                collision.GetComponent<PlayerHealth>().HealPlayer(purplePotionHeal);
                // 

                Destroy(gameObject);
                //
            }
        }

    }


}
