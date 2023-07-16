using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCollectibles : MonoBehaviour
{
    public Timer timer;
    public FloatingTextManager floatingTextManager;
    [SerializeField] private float sec;

    //slows time for specific seconds

    // Start is called before the first frame update
    void Start()
    {
        sec = 5f;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("i collide");
        if (collision.gameObject.CompareTag("Tera"))
        { 
           
            //add floating text
            floatingTextManager.Show("Time slowed for " + sec+ " seconds!", 38, Color.white, transform.position, Vector3.up, 2.5f);

            if (gameObject.CompareTag("timeslower"))
            {
                
                timer.SlowTime(sec);


                Destroy(gameObject);

            }


        }
        if (collision.gameObject.CompareTag("Kev"))
        {

            //add floating text
            floatingTextManager.Show("Time slowed for " + sec + " seconds!", 38, Color.white, transform.position, Vector3.up, 2.5f);

            if (gameObject.CompareTag("timeslower"))
            {

                timer.SlowTime(sec);


                Destroy(gameObject);

            }


        }
    }
}
