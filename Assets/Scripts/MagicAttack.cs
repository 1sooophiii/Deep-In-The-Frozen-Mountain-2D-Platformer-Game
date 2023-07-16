using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
   
    public float speed ;
    public Rigidbody2D rb;
    public int magicDamage;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        magicDamage = GameObject.FindGameObjectWithTag("Tera").GetComponent<PlayerAttack>().damage;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tera"))
        {
            //to not collide with self
            return;
        }

        if (collision.GetComponent<Enemy>())
        {
            //calls damage function from other class
            collision.GetComponent<Enemy>().TakeDamage(magicDamage);
         
            Destroy(gameObject);

        }
        if (collision.GetComponent<Boss>())
        {
            //calls damage function from other class
            collision.GetComponent<Boss>().TakeDamage(magicDamage);
          
            Destroy(gameObject);

        }


    }




}
