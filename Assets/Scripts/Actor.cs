using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health: " + currentHealth);
        if(currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        // Death function
        KillCounter.instance.killCount++;
        KillCounter.instance.UpdateKillCount();
        Destroy(gameObject);
    }

}
