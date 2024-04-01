using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackPlayer2 : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask player1Layer;

    [SerializeField] private AudioSource punchingSoundEffect;

    public int damageAmount = 10;
    public float attackRange = 0.5f;
    
    
    
    private void Update()

    {
        if (Input.GetButtonDown("Fire2"))
        {
            DamageOpponent();
        }
    }


    private void DamageOpponent()
    {
        {
            punchingSoundEffect.Play();   
            anim.SetTrigger("punching");
            Collider2D[] hitPlayer1 = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player1Layer);
            foreach(Collider2D player1 in hitPlayer1)
        {
            player1.GetComponent<Player1Health>().TakeDamage(damageAmount);
        }
        } 
    }
    void OnDrawGizmosSelected()
    { 
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


