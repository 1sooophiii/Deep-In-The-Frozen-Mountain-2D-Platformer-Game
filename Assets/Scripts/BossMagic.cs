using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMagic : MonoBehaviour
{
    //private Boss boss;
    private Transform player;

    public float speed;
    public Rigidbody2D rb;
    [SerializeField] private int magicDamage;

    // Start is called before the first frame update
    void Start()
    {
        //get player's transform and rigidbody of the magic
        rb.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("CurrentPlayerPos").GetComponent<Transform>();


        Vector2 AttackDir = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(AttackDir.x, AttackDir.y);

    }


    // Update is called once per frame
   // void Update()
    //{
     
        //follow player (targeted attack)
       // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

   // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("boss"))
        {
            return;

        }
        else if (collision.gameObject.CompareTag("Tera"))
        //if (collision.GetComponent<PlayerHealth>())
        {
            //damage player
            collision.GetComponent<PlayerHealth>().DamagePlayer(magicDamage);


            //destroy magic
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.CompareTag("Kev"))
        //if (collision.GetComponent<PlayerHealth>())
        {
            //damage player
            collision.GetComponent<PlayerHealth>().DamagePlayer(magicDamage);


            //destroy magic
            Destroy(this.gameObject);

        }



    }
}
