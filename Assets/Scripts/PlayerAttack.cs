using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public FloatingTextManager floatingTextManager;

    public int damage = 3;
    public int normalDamage = 3;

    public Transform attackpoint;
    public GameObject magicAttackPrefab;
    [SerializeField] private float firerate;
    private float nextfire;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    //creates a magic attack that travels forward to the direction where the player looks
    //and at a specific rate
    void Attack()
    {
        if(nextfire < Time.time)
        { 
            Instantiate(magicAttackPrefab, attackpoint.position, attackpoint.rotation);
            nextfire = Time.time + firerate;
        }

    }


    public void IncreaseAttack(int addedDamage, float seconds)
    {
        floatingTextManager.Show("Increased Damage for " + seconds + " Seconds!", 40, Color.black, transform.position, Vector3.up, 2.5f);

        damage += addedDamage;

        Invoke("ReturnToNormalDamage", seconds);

    }

    public void ReturnToNormalDamage()
    {

        damage = normalDamage;

    }
}
