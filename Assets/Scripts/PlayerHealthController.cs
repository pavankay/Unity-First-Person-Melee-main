using UnityEngine;
using UnityEngine.UI;  // Needed for the Slider

public class PlayerHealthController : MonoBehaviour
{
    public Slider healthSlider;  // Reference to the UI Slider
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player took damage: " + damageAmount);

        // Update the health slider
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
            
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add death behavior here (e.g., restart level, disable player, etc.)
    }
}
