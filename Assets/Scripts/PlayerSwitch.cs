using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject Tera, Kev;

    public Transform currentPlayerPosition;


    int CurrentCharacter = 1;

    // Start is called before the first frame update
    void Start()
    {
        Tera.gameObject.SetActive(true);
        Kev.gameObject.SetActive(false);
       

    }

    public void SwitchCharacter()
    {
        switch (CurrentCharacter)
        {
            case 1:

                CurrentCharacter = 2;
                Tera.gameObject.SetActive(false);
                Kev.gameObject.SetActive(true);

                break;

            case 2:

                CurrentCharacter = 1;
                Tera.gameObject.SetActive(true);
                Kev.gameObject.SetActive(false);

                break;

        }
    }


    public void UpdatePosition()
    {
        switch (CurrentCharacter)
        {
            case 1:

            
               currentPlayerPosition.position = Tera.transform.position;

                break;

            case 2:

            
                currentPlayerPosition.position = Kev.transform.position;

                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            SwitchCharacter();
        }

        UpdatePosition();


    }
}
