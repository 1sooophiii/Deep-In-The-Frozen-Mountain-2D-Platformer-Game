using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevMeleeAttack : MonoBehaviour
{
    public FloatingTextManager floatingTextManager;

    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;


    public int damage = 6;
    public int normalDamage = 6;

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
        if (nextfire < Time.time)
        {
            animator.SetTrigger("Attack");

            Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);


            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);

            }

            foreach (Collider2D boss in hitBoss)
            {
                 boss.GetComponent<Boss>().TakeDamage(damage);
            }


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
