using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : MonoBehaviour
{
    public int maxHealth1 = 100;
    public int currentHealth1;
    

    void Start()
    {
        currentHealth1 = maxHealth1;
    }

    public void TakeDamage(int amount)
    {
        currentHealth1 -= amount;
        if (currentHealth1 <= 0)
        {
            Die1();
        }
    }

    void Die1()
    {
        Debug.Log("Player 1 died!");
        GameObject.FindGameObjectWithTag("Player1").SetActive(false);
    }
}