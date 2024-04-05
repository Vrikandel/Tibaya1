using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAttack : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public PlayerMovement2 playerMovement2;
    public Abilites abilites;

    public Animator anim;
    private SpriteRenderer sprite;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public LayerMask player2Layer;
    public GameObject popUpPrefab;
    private Transform currentattackpoint;

    [SerializeField] private AudioSource punchingSoundEffect;
    [SerializeField] private AudioSource powerUpSoundEffect;
    [SerializeField] private AudioSource powerUpOverSoundEffect;

    private bool canPowerUp = true;
    private float powerupDamage;
    public float powerupDuration = 3f;
    public float powerupCooldown = 5f;
    public float powerupDamageMultiplier = 2f;

    public float attackRange = 0.5f;
    public int damageAmount = 10;
    public float attackRate = 3f;
    private float nextAttackTime = 0f;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
        playerMovement = GetComponent<PlayerMovement>();
        currentattackpoint = attackPoint1;
    }
    private void Update()
    {

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                DamageOpponent();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (sprite.flipX == true)
            {
                SwitchAttackPoint1();
            }
        }
        if (Input.GetButtonDown("PowerUp") && canPowerUp)
        {
            
            StartCoroutine(PowerUp());
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
            GameObject popUp = Instantiate(popUpPrefab, player2.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damageAmount.ToString();
            if (transform.position.x >player2.transform.position.x)
                popUp.GetComponent<PopUpDamage>().hitFromRight = true;

            playerMovement2.KBCounter = playerMovement2.KBTotalTime;
            if (player2.transform.position.x <= transform.position.x)
            {
                playerMovement2.KnockfromRight = true;
            }
            if (player2.transform.position.x > transform.position.x)
            {
                playerMovement2.KnockfromRight = false;
            }
            player2.GetComponent<Player2Health>().TakeDamage(damageAmount);
        }

    
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
    }

    private IEnumerator PowerUp()
    {
        powerUpSoundEffect.Play();
        canPowerUp = false;
        int originaldamageAmount = damageAmount;
        powerupDamage = powerupDamageMultiplier * damageAmount;
        damageAmount = (int)powerupDamage;
        Debug.Log(damageAmount);
        yield return new WaitForSeconds(powerupDuration);
        powerUpOverSoundEffect.Play();
        damageAmount = originaldamageAmount;
        Debug.Log(damageAmount);
        yield return new WaitForSeconds(powerupCooldown);
        canPowerUp = true;
    }

    private void SwitchAttackPoint1()
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



