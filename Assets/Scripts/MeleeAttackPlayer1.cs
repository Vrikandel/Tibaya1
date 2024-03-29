using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Player2Health player1Health;
    public int damageAmount = 10;
    public string opponentTag;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DamageOpponent();
        }
    }


    private void DamageOpponent()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);

        foreach (Collider2D collider in colliders)
        { 
            Player2Health player2Health = collider.gameObject.GetComponent<Player2Health>();
            if (player2Health != null)
            {
                player2Health.TakeDamage(damageAmount);
            }
        }
    }
        
 }



