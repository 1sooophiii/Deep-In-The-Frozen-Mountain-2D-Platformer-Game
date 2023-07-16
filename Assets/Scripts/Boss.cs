using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{

    // public PlayerHealth playerhealth;

    public PlayerXP playerxp;

    public int BossmaxHealth = 80;

    public int BosscurrentHealth;

    public HealthBar Bosshealthbar;

    [SerializeField] private int BossDamage;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject playerTransformTera;
    [SerializeField] private GameObject playerTransformKev;

    private Transform targetPlayer;

    [SerializeField] private float Bossspeed;


    [SerializeField] private float detectrange;
    [SerializeField] private float attackrange;
    [SerializeField] private float firerate = 1f;

    private float nextfire;

    public GameObject BossmagicAttackPrefab;
    public GameObject BossmagicAttackPrefabParent;

    public GameObject CrystalPrefab;
    private GameObject crystal;



    public void TakeDamage(int damage)
    {
        //reduce boss's health
        BosscurrentHealth -= damage;


        if (BosscurrentHealth <= 0)
        {
            BossDeath();
        }
        //update health bar and animation condition
        Bosshealthbar.setHealth(BosscurrentHealth);
        animator.SetInteger("BossHealth", BosscurrentHealth);

    }

    void BossDeath()
    {

        //change animation
        animator.Play("wraithdeath");
        //destroy boss
        Destroy(gameObject, 1f);
        //give player 60 xp and update UI
        playerxp.GetXP(60);
        //give crystal to the player
        if (crystal == null)
        {
            crystal = Instantiate(CrystalPrefab, this.transform.position, Quaternion.identity);
        }




    }

    public Transform GetplayerActivePosition()
    {
        if (playerTransformTera.activeSelf)
        {
            //Debug.Log("im heree"+ playerTransformTera.activeSelf );
            //targetPlayer = playerTransformTera.transform;
            targetPlayer = GameObject.FindGameObjectWithTag("Tera").GetComponent<Transform>();
        }
        else if (playerTransformKev.activeSelf)
        {
            //targetPlayer = playerTransformKev.transform;
            targetPlayer = GameObject.FindGameObjectWithTag("Kev").GetComponent<Transform>();
        }
       // Debug.Log(targetPlayer);
        return targetPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        //set health
        BosscurrentHealth = BossmaxHealth;
        Bosshealthbar.setMaxHealth(BossmaxHealth);
        //get animator
        animator = GetComponent<Animator>();
        //get player's transform
        // targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPlayer = GetplayerActivePosition();

    }

    // Update is called once per frame
    void Update()
    {
        //check which player is active
        targetPlayer = GetplayerActivePosition();

        //follow and attack player

        float distancefromplayer = Vector2.Distance(transform.position, targetPlayer.position);
        if ( distancefromplayer < detectrange && distancefromplayer > attackrange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, targetPlayer.position,
                Bossspeed * Time.deltaTime);
        }
        else if(distancefromplayer <= attackrange && nextfire <Time.time)
        {
            Instantiate(BossmagicAttackPrefab, BossmagicAttackPrefabParent.transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
        //flip
         if(transform.position.x < targetPlayer.position.x)
        {
             transform.localScale = new Vector3(-1, 1, 1);
         }
         else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }


    }


}

