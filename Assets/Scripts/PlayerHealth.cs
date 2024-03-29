using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth2;

    void Start()
    {
        currentHealth2 = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth2 -= amount;
        if (currentHealth2 <= 0)
        {
            Die2();
        }
    }
    
    void Die2()
    {
        Debug.Log("Player 2 died!");
        GameObject.FindGameObjectWithTag("Player2").SetActive(false);
    }
}