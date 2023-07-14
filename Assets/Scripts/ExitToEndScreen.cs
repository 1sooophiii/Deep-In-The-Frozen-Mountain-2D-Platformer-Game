using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitToEndScreen : MonoBehaviour
{


    public GameObject containerInteract;
    public Text interactText;
    public string text;


    void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Tera" || collision.gameObject.tag == "Kev")
        {
            interactText.text = text;
            containerInteract.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        containerInteract.SetActive(false);
    }

   
    
}

