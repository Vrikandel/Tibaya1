using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    public float dirX2 = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockfromRight;

    private bool wasAirborne = false;

    private enum AnimationState { idle, running, jumping, falling, punching }

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
        if (KBCounter <= 0)
        {
            dirX2 = Input.GetAxisRaw("Horizontal2");
            rb.velocity = new Vector2(dirX2 * moveSpeed, rb.velocity.y);
        }
        else
        {
            if (KnockfromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if(KnockfromRight == false)
            {
               rb.velocity = new Vector2(KBForce, KBForce); 
            }
            KBCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump2") && IsGrounded())
            { 
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

        LandingCheck();
        WalkingCheck();
        UpdateAninimationState();
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
            if (dirX2 != 0f && IsGrounded())
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



    private void UpdateAninimationState()
    {
        AnimationState state;
        if (dirX2 > 0f)
        {
            state = AnimationState.running;
            sprite.flipX = false;
        }
        else if (dirX2 < 0f)
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
