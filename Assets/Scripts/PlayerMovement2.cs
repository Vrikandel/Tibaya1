using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>(); 
        coll = GetComponent<BoxCollider2D>(); 
    }

    private void Update()  
    {
        dirX = Input.GetAxisRaw("Horizontal2");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump2") && IsGrounded())
            { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
             }
        UpdateAninimationState();
    }
    private void UpdateAninimationState()
    {
        if (dirX < 0f)
        {
            sprite.flipX = true;
        }
        else if (dirX > 0f)
        {
            sprite.flipX = false;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
