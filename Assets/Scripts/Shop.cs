using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject containerInteract;
    public Text interactText;
    public string text;

    public Inventory inventory;
    public GameObject itemicon;
    public string itemtype;

    public int XPPrice;


    private void Start()
    {
        itemtype = tag;
    }

    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Tera" || collision.gameObject.tag == "Kev")
        {
            interactText.text = text;
            containerInteract.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerXP.Instance.currentXP >= XPPrice)
                {
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

                                PlayerXP.Instance.LoseXP(XPPrice);

                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
            containerInteract.SetActive(false);
    }



}
