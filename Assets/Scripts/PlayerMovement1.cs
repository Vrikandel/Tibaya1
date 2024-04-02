using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private  Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    public float dirX = 0f;
   [SerializeField] private float moveSpeed = 7f;
   [SerializeField] private float jumpForce = 14f;

   private bool wasAirborne = false;

   public enum AnimationState { idle, running, jumping, falling, punching }
   [SerializeField] private AudioSource jumpSoundEffect;
   [SerializeField] private AudioSource landingSoundEffect;
   [SerializeField] private AudioSource walkingSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();  
        coll = GetComponent<BoxCollider2D>(); 
        anim = GetComponent<Animator>();   
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
        UpdateAnimationState();
        LandingCheck();
        WalkingCheck();
    }
    private void LandingCheck()
    {
        if (!wasAirborne && !IsGrounded() && rb.velocity.y < 0f)
        {
            wasAirborne = true;
        }
        else if (wasAirborne && IsGrounded())
        {
            wasAirborne = false;
            landingSoundEffect.Play();
        }
    }
    private void WalkingCheck()
    { 
        if (dirX != 0f && IsGrounded())
        {
            if (!walkingSoundEffect.isPlaying)
            {
                walkingSoundEffect.Play();
            }
        }
        else
        {
            walkingSoundEffect.Stop();
        }

    }

    public void UpdateAnimationState()
    {
        AnimationState state;

        if (dirX > 0f)
        {
            state = AnimationState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = AnimationState.running;
            sprite.flipX = true;
        }
        
        else if (rb.velocity.y > .1f)
        {
            state = AnimationState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = AnimationState.falling;
        }

        else
        {
            state = AnimationState.idle;
        }
        anim.SetInteger("state", (int)state);
    }      
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}   
