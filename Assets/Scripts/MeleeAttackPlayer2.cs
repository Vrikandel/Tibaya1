using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackPlayer2 : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public LayerMask player1Layer;

    [SerializeField] private AudioSource punchingSoundEffect;

    private PlayerMovement2 playerMovement2;

    public int damageAmount = 10;
    public float attackRange = 0.5f;
    private Transform currentattackpoint;


    private void Start()
    {
        playerMovement2 = GetComponent<PlayerMovement2>();
        currentattackpoint = attackPoint1;
    }

    private void Update()

    {
        if (Input.GetButtonDown("Fire2"))
        {
            DamageOpponent();
        }
        if (playerMovement2.dirX2 > 0)
        {
            SwitchAttackPoint();
        }
    }


    private void DamageOpponent()
    {
        {
            if (punchingSoundEffect != null)
                punchingSoundEffect.Play();   
            anim.SetTrigger("punching");
            Collider2D[] hitPlayer1 = Physics2D.OverlapCircleAll(currentattackpoint.position, attackRange, player1Layer);
            foreach(Collider2D player1 in hitPlayer1)
        {
            player1.GetComponent<Player1Health>().TakeDamage(damageAmount);
        }
        } 
    }
    private void SwitchAttackPoint()
    {
        if (currentattackpoint == attackPoint1)
        {
            currentattackpoint = attackPoint2;
        }
        else
        {
            currentattackpoint = attackPoint1;
        }
    }
}


