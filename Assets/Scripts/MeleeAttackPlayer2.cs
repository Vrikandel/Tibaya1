using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackPlayer2 : MonoBehaviour
{
    public int damageAmount = 10;
    public string opponentTag;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            DamageOpponent();
        }
    }


    private void DamageOpponent()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);

        foreach (Collider2D collider in colliders)
        {
            Player1Health player1Health = collider.gameObject.GetComponent<Player1Health>();
            if (player1Health != null)
            {
                player1Health.TakeDamage(damageAmount);
            }
        }
    }

}
