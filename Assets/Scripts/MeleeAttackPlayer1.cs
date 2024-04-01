using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask player2Layer;

    [SerializeField] private AudioSource punchingSoundEffect;

    public float attackRange = 0.5f;
    public int damageAmount = 10;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            DamageOpponent();
        }

    }


    private void DamageOpponent()
    {
        punchingSoundEffect.Play();
        anim.SetTrigger("punching");
        Collider2D[] hitPlayer2 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player2Layer);
        foreach(Collider2D player2 in hitPlayer2)
        {
            player2.GetComponent<Player2Health>().TakeDamage(damageAmount);
        }
    }
     void OnDrawGizmosSelected()
     { 
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
     }

        
}



