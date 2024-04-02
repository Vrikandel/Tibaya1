using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public LayerMask player2Layer;

    [SerializeField] private AudioSource punchingSoundEffect;

    private PlayerMovement playerMovement;

    public float attackRange = 0.5f;
    public int damageAmount = 10;
    private Transform currentattackpoint;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        currentattackpoint = attackPoint1;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            DamageOpponent();
        }
        if (playerMovement.dirX > 0)
        {
            SwitchAttackPoint();
        }
    }


    private void DamageOpponent()
    {
        if (punchingSoundEffect != null)
            punchingSoundEffect.Play();
        anim.SetTrigger("punching");

        Collider2D[] hitPlayer2 = Physics2D.OverlapCircleAll(currentattackpoint.position, attackRange, player2Layer);
        foreach(Collider2D player2 in hitPlayer2)
        {
            player2.GetComponent<Player2Health>().TakeDamage(damageAmount);
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



