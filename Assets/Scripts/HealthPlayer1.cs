using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer1 : MonoBehaviour
{
    public Image HealthBar1;
    public float HealthAmount = 100;

    private void Update()
    {
        if(HealthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float Damage)
    {
        HealthAmount -= Damage;
        HealthBar1.fillAmount = HealthAmount / 100;
    }

   
} 

