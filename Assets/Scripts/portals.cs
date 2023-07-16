using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class portals : MonoBehaviour
{
    [SerializeField] private Transform nextArea;
    [SerializeField] private Transform Tera;
    [SerializeField] private Transform Kev;

    public GameObject containerInteract;
    public Text interactText;
    public string text;


    //if player enters portal then is teleported to the position given along with the camera
    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Tera" || collision.gameObject.tag == "Kev")
        {
            interactText.text = text;
            containerInteract.SetActive(true);


            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Ipresse");
                Teleport();
            }
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        containerInteract.SetActive(false);
    }

    void Teleport()
    {
       
            containerInteract.SetActive(false);
            Tera.transform.position = new Vector3(nextArea.position.x, nextArea.position.y, 0f);
            Kev.transform.position = new Vector3(nextArea.position.x, nextArea.position.y, 0f);


            Camera.main.transform.position = nextArea.position;
        
    }

}
