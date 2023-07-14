using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public FloatingTextManager floatingTextManager;

    public float speed = 0.3f;
    public float normalSpeed = 0.3f;

    [SerializeField] private float jumpspeed = 0.8f;

    [SerializeField] private AudioSource jumpsound;


    private float Hmovement;
    private bool canDoubleJump;

    private bool facingright =  true;

    private Animator animator;
    private Rigidbody2D rb2D;
    
    private BoxCollider2D playerCollider;

    [SerializeField] private LayerMask groundLayer;

    private enum MovementState { idle, walk, jump }



    public override void OnNetworkDespawn()
    {
        if (!IsOwner) Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {

        //move
        Hmovement = Input.GetAxisRaw("Horizontal");

        rb2D.velocity = new Vector2(Hmovement * speed, rb2D.velocity.y);

      
        //jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
                canDoubleJump = true;
                //animator.SetBool("Jumping", true);
                jumpsound.Play();
            }
            else
            {
                if (canDoubleJump) 
                { 
                    canDoubleJump = false;
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpspeed);
                    jumpsound.Play();
                }
            }
        }

        //flips the sprite of the player depending on whether he moves left or right
        if (Hmovement != 0)
        {
            if (Hmovement > 0 && !facingright)
            {
                
                flip();
            }
            else if (Hmovement <0 && facingright)
            {
               
                flip();

            }
        }
      
        UpdateAnimationState();
    }

    private void flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }

    //animation states
    private void UpdateAnimationState()
    {
        MovementState state;

        if (Hmovement != 0f)
        {
            state = MovementState.walk;
            
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb2D.velocity.y > .1f)
        {
            state = MovementState.jump;
        }

        animator.SetInteger("MovementState", (int)state);

    }

    //checks if player is grounded
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }


   
    public void IncreaseSpeed(float addedSpeed, float seconds)
    {
        floatingTextManager.Show("Increased Speed for " + seconds + " Seconds!", 40, Color.yellow, transform.position, Vector3.up, 2.5f);

        speed += addedSpeed;

        Invoke("ReturnToNormalSpeed", seconds);

    }

    public void ReturnToNormalSpeed()
    {

        speed = normalSpeed;

    }

}
