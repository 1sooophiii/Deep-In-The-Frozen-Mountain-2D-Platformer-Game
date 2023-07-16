using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public FloatingTextManager floatingTextManager;

    public int maxHealth;

    public int currentHealth;

    public HealthBar healthbar;

    private Rigidbody2D rb2D;

    public GameObject YoudiedUI;

    private void Awake()
    {
        
        Instance = this;
       
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();


        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

  

  

    //damages player and updates the gui
    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) PlayerDeath();
        healthbar.setHealth(currentHealth);
        floatingTextManager.Show("-" + damage + " Health!", 38, Color.red, transform.position, Vector3.up, 2.5f);
        
    }

    //heals player and updates teh gui
    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
        floatingTextManager.Show("+" + heal + " Health!", 38, Color.green, transform.position, Vector3.up, 2.5f);

    }

    //shows panel with restart level and quit game
    void PlayerDeath()
    {
        //rb2D.bodyType = RigidbodyType2D.Static;
       
        YoudiedUI.gameObject.SetActive(true);
        Time.timeScale = 0f;


    }

  
}
