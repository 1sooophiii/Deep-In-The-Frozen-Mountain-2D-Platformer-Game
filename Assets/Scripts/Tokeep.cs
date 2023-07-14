using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tokeep : MonoBehaviour
{
    [HideInInspector]
    public string ID;

    private void Awake()
    {
        ID = name + transform.position.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i < Object.FindObjectsOfType<Tokeep>().Length; i++)
        {
            if(Object.FindObjectsOfType<Tokeep>()[i] != this)
            {
                if(Object.FindObjectsOfType<Tokeep>()[i].ID == ID)
                {
                    Destroy(gameObject);
                }
            }
        }


        DontDestroyOnLoad(gameObject);
    }

}
