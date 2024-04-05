using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilites : MonoBehaviour
{
    public Image powerupImage;
    public Text powerupText;
    public float powerupCooldown;
    private float currentCooldown1;
    private bool isCooldown1 = false;

    public Image dashImage;
    public Text dashText;
    public float dashCooldown;
    private float currentCooldown2;
    private bool isCooldown2 = false;
    
    

    
    void Start()
    {
      powerupImage.fillAmount = 0f;
      powerupText.text ="";

      dashImage.fillAmount = 0f;
      dashText.text ="";
    }   

    void Update()
    {
        Ability1Input();
        Ability2Input();

        AbilityCooldown(ref currentCooldown1, powerupCooldown, ref isCooldown1, powerupImage, powerupText);
        AbilityCooldown(ref currentCooldown2, dashCooldown, ref isCooldown2, dashImage, dashText);
    }

    private void Ability1Input()
    {
        if (Input.GetButtonDown("PowerUp") && !isCooldown1)
        {
            isCooldown1 = true;
            currentCooldown1 = powerupCooldown;

        }
    }
    private void Ability2Input()
    {
        if (Input.GetButtonDown("AbilityDash") && !isCooldown2)
        {
            isCooldown2 = true;
            currentCooldown2 = dashCooldown;
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
                   
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}