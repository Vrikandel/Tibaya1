using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player1Health : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Score scorePlayer2;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text HpText;
    [SerializeField] private Text Score2Text;

    public int maxHealth1 = 100;
    public int currentHealth1;
    private int hp;
    private int score2;

    void Start()
    {
        scorePlayer2 = GetComponent<Score>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth1 = maxHealth1;
        hp = maxHealth1;
        
        
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
        hp = hp -amount;
        HpText.text = "HP:" + hp;
        currentHealth1 -= amount;
        if (currentHealth1 <= 0)
        {
            Die1();
        }
    }
    
    private void Die1()
    {
        score2 = score2 + 1;
        Score2Text.text = "Score:" + score2;
        PlayerPrefs.SetInt("Score2", score2);
        PlayerPrefs.Save();
        Debug.Log("Score before reload: " + score2);

        deathSoundEffect.Play();
        Debug.Log("Player 1 died! Score:" + score2);
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;

        
        Invoke("RestartLevel", 1.0f);
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        score2 = PlayerPrefs.GetInt("Score2", 0);
        Debug.Log("Loaded Score: " + score2);
        Score2Text.text = "Score:" + score2;

    }
}