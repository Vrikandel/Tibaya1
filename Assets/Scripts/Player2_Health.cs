using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Health : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

[SerializeField] private AudioSource deathSoundEffect;

    public int maxHealth2 = 100;
    public int currentHealth2;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth2 = maxHealth2 ;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die2();
        }

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
        deathSoundEffect.Play();
        anim.SetTrigger("death");
        Debug.Log("Player 2 died!");
        rb.bodyType = RigidbodyType2D.Static; 
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}