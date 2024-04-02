using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeAttackPlayer2 : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sprite;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public LayerMask player1Layer;
    public GameObject popUpPrefab;

    [SerializeField] private AudioSource punchingSoundEffect;

    private PlayerMovement2 playerMovement2;
    public PlayerMovement playerMovement1;

    public int damageAmount = 10;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private Transform currentattackpoint;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        playerMovement2 = GetComponent<PlayerMovement2>();
        currentattackpoint = attackPoint1;
    }

    private void Update()

    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                DamageOpponent();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (sprite.flipX == true)
            {
                SwitchAttackPoint2();
            }
        }
    }


    private void DamageOpponent()
    {
        {
            if (punchingSoundEffect != null)
                punchingSoundEffect.Play();   
            anim.SetTrigger("punching");
            Collider2D[] hitPlayer1 = Physics2D.OverlapCircleAll(currentattackpoint.position, attackRange, player1Layer);
            foreach(Collider2D player1 in hitPlayer1)
        {
            GameObject popUp = Instantiate(popUpPrefab, player1.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damageAmount.ToString();
            if (transform.position.x >player1.transform.position.x)
                popUp.GetComponent<PopUpDamage>().hitFromRight = true;

            playerMovement1.KBCounter = playerMovement1.KBTotalTime;
            if(player1.transform.position.x <= transform.position.x)
            {
                playerMovement1.KnockfromRight = true;
            }
            if(player1.transform.position.x > transform.position.x)
            {
                playerMovement1.KnockfromRight = false;
            }
            player1.GetComponent<Player1Health>().TakeDamage(damageAmount);
        }
        } 
    }
    private void SwitchAttackPoint2()
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


