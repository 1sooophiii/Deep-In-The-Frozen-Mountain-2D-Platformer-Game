using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private GameObject Tera;
    [SerializeField] private GameObject Kev;
    private GameObject player;
    private PlayerHealth playerhealth;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttackTera;
    private KevMeleeAttack playerAttackKev;

    public Inventory inventory;
    public int i;

    public GameObject itemiconpurplepotion;
    public GameObject itemicongreenpotion;
    public GameObject itemiconorangepotion;



    private void Start()
    {
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (MainManager.Instance != null)
        {
            SetInventory();
        }


        if (Tera.activeSelf)
        {
            player = Tera;
            playerhealth = Tera.GetComponent<PlayerHealth>();
            playerMovement = Tera.GetComponent<PlayerMovement>();
            playerAttackTera = Tera.GetComponent<PlayerAttack>();
        }
        else if (Kev.activeSelf)
        {

            player = Kev;
            playerhealth = Kev.GetComponent<PlayerHealth>();
            playerMovement = Kev.GetComponent<PlayerMovement>();
            playerAttackKev = Kev.GetComponent<KevMeleeAttack>();
        }


    }

    // Update is called once per frame
    private void Update()
    {

        if (Tera.activeSelf)
        {
            player = Tera;
            playerhealth = Tera.GetComponent<PlayerHealth>();
            playerMovement = Tera.GetComponent<PlayerMovement>();
            playerAttackTera = Tera.GetComponent<PlayerAttack>();
        }
        else if (Kev.activeSelf)
        {

            player = Kev;
            playerhealth = Kev.GetComponent<PlayerHealth>();
            playerMovement = Kev.GetComponent<PlayerMovement>();
            playerAttackKev = Kev.GetComponent<KevMeleeAttack>();
        }

        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (i == 0)
            {
                GetComponent<Button>().onClick.Invoke();
                UseItem(inventory.itemtype[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (i == 1)
            {
                GetComponent<Button>().onClick.Invoke();
                UseItem(inventory.itemtype[i]);

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (i == 2)
            {
                GetComponent<Button>().onClick.Invoke();
                UseItem(inventory.itemtype[i]);

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (i == 3)
            {
                GetComponent<Button>().onClick.Invoke();
                UseItem(inventory.itemtype[i]);

            }
        }

        GetInventory();
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

    }



    public void UseItem(string itemtype)
    {
        // purple potion heals, green potion makes player faster for some sec, orange potion makes attack stronger for some sec,
        // blue potion makes player immune to damage for some sec)

        switch (itemtype)
        {
            case "green potion":


                Debug.Log(" I used green potion");


                playerMovement.IncreaseSpeed(0.2f, 5);


                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                inventory.itemtype[i] = null;
                break;

            case "purple potion":

                //do this (for example extra damage on the next 2 hits)
                Debug.Log(" I used purple potion");


                playerhealth.HealPlayer(5);


                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                inventory.itemtype[i] = null;
                break;

            case "orange potion":

                //do this (for example extra damage on the next 2 hits)
                Debug.Log(" I used orange potion");


                if (player == Tera)
                {
                    playerAttackTera.IncreaseAttack(2, 5);
                }
                else if (player == Kev)
                {
                    playerAttackKev.IncreaseAttack(2, 5);

                }


                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                inventory.itemtype[i] = null;
                break;
        }
        GetInventory();
    }


    void GetInventory()
    {
        MainManager.Instance.inventoryslot1 = inventory.itemtype[0];
        MainManager.Instance.inventoryslot2 = inventory.itemtype[1];
        MainManager.Instance.inventoryslot3 = inventory.itemtype[2];
        MainManager.Instance.inventoryslot4 = inventory.itemtype[3];
    }

    void SetInventory()
    {
        inventory.itemtype[0] = MainManager.Instance.inventoryslot1;
        inventory.itemtype[1] = MainManager.Instance.inventoryslot2;
        inventory.itemtype[2] = MainManager.Instance.inventoryslot3;
        inventory.itemtype[3] = MainManager.Instance.inventoryslot4;


        for (int i = 0; i <= 3; i++)
        {
            if(inventory.itemtype[i] == "purple potion")
            {
                Instantiate(itemiconpurplepotion, inventory.slots[i].transform, false);
                inventory.isFull[i] = true;
               
            }
            if (inventory.itemtype[i] == "green potion")
            {
                Instantiate(itemicongreenpotion, inventory.slots[i].transform, false);
                inventory.isFull[i] = true;
                
            }
            if (inventory.itemtype[i] == "orange potion")
            {
                Instantiate(itemiconorangepotion, inventory.slots[i].transform, false);
                inventory.isFull[i] = true;

            }


        }

    }
}
