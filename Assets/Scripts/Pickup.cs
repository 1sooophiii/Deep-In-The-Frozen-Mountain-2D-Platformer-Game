using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemicon;
    public string itemtype;

    private void Start()
    {
       // inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        itemtype = tag;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collided");
        if (collider.gameObject.CompareTag("Tera"))
        {
            //Debug.Log("i detect tera");
            if (gameObject.CompareTag(itemtype))
            {
                //Debug.Log("i deteect green potion");
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    Debug.Log("i go inside here" + inventory.slots.Length);
                    if (inventory.isFull[i] == false)
                    {
                        // Debug.Log(inventory.isFull[i]);
                        inventory.itemtype[i] = itemtype;
                        inventory.isFull[i] = true;
                        Instantiate(itemicon, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
        if (collider.gameObject.CompareTag("Kev"))
        {
            if (gameObject.CompareTag(itemtype))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.itemtype[i] = itemtype;
                        inventory.isFull[i] = true;
                        Instantiate(itemicon, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
