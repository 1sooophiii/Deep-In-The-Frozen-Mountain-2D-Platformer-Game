using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private PlayerHealth playerhealthTera;
    private PlayerHealth playerhealthKev;


    public PlayerXP playerxp;

    public int enemymaxHealth = 10;

    public int enemycurrentHealth;

    public HealthBar enemyhealthbar;

    [SerializeField] private int enemyDamage;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject playerTransformTera;
    [SerializeField] private GameObject playerTransformKev;

    private Transform targetPlayer;

    [SerializeField] private float enemyspeed;

    [SerializeField] private float detectrange;


    //damage enemy and update gui
    public void TakeDamage(int damage)
    {
        enemycurrentHealth -= damage;
        

        if (enemycurrentHealth <= 0)
        {
            EnemyDeath();
        }

        enemyhealthbar.setHealth(enemycurrentHealth);
        animator.SetInteger("EnemyHealth", enemycurrentHealth);

    }

    //destroy enemy and show animation
    void EnemyDeath()
    {
        
        animator.Play("poisonousmushroomdeathanim");


        Destroy(gameObject, 0.15f);
        //give player 20 xp and update ui
        playerxp.GetXP(20);

    }

    // Start is called before the first frame update
    void Start()
    {
        playerhealthTera = playerTransformTera.GetComponent<PlayerHealth>();
        playerhealthKev = playerTransformKev.GetComponent<PlayerHealth>();

        enemycurrentHealth = enemymaxHealth;
        enemyhealthbar.setMaxHealth(enemymaxHealth);

        animator = GetComponent<Animator>();
        targetPlayer = GetplayerActivePosition();

    }

    // Update is called once per frame
    void Update()
    {
        targetPlayer = GetplayerActivePosition();

        if (Vector2.Distance(transform.position, targetPlayer.position) <= detectrange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, targetPlayer.position,
                enemyspeed * Time.deltaTime);
        }

       // if(transform.position.x < targetPlayer.position.x)
       // {
       //     transform.localScale = new Vector3(-1, 1, 1);
       // }
       // else
       // {
       //     transform.localScale = new Vector3(1, 1, 1);
       // }


    }
    public Transform GetplayerActivePosition()
    {
        if (playerTransformTera.activeSelf)
        {
            Debug.Log("im heree");
            //targetPlayer = playerTransformTera.transform;
            targetPlayer = GameObject.FindGameObjectWithTag("Tera").GetComponent<Transform>();
        }
        else if (playerTransformKev.activeSelf)
        {
            //targetPlayer = playerTransformKev.transform;
            targetPlayer = GameObject.FindGameObjectWithTag("Kev").GetComponent<Transform>();
        }
        Debug.Log(targetPlayer);
        return targetPlayer;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("i collide");
        if (collision.gameObject.CompareTag("Tera"))
        {
            //Debug.Log("i collide with tera");
            
            if (gameObject.CompareTag("enemy"))
            {

                //Debug.Log("i do damage");

                playerhealthTera.DamagePlayer(enemyDamage);

                
            }


        }
        if (collision.gameObject.CompareTag("Kev"))
        {
            //Debug.Log("i collide with tera");

            if (gameObject.CompareTag("enemy"))
            {

                //Debug.Log("i do damage");

                playerhealthKev.DamagePlayer(enemyDamage);


            }


        }
    }

}
