using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;

    public float currHealth;
    public float maxHealth = 100f;

    public HealthBar healthBar;

    private void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15f);
        }
    }

    private void TakeDamage(float damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }
}
