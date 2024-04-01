using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Health : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathSoundEffect;

    public int maxHealth1 = 100;
    public int currentHealth1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth1 = maxHealth1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die1();
        }

    }

    public void TakeDamage(int amount)
    {
        currentHealth1 -= amount;
        if (currentHealth1 <= 0)
        {
            Die1();
        }
    }
    
    private void Die1()
    {
        deathSoundEffect.Play();
        Debug.Log("Player 1 died!");
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
}