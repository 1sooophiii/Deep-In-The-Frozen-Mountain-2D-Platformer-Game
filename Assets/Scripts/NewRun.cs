using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewRun : MonoBehaviour
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

                StartOver();
            }
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        containerInteract.SetActive(false);
    }

    void StartOver()
    {
        SceneManager.LoadScene("Forest");
    }


}
