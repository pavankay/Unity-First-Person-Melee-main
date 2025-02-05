using UnityEngine;

public class SwordCollisionController : MonoBehaviour
{
    public int damageAmount = 10;  // Amount of damage the sword deals

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the sword hit the player
        {
            Debug.Log("Sword hit the player!");

            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();

            // Only deal damage if the enemy is attacking and allowed to deal damage
            if (playerHealth != null && EnemyAiController.isAttacking && EnemyAiController.canDealDamage)
            {
                playerHealth.TakeDamage(damageAmount);  // Apply damage to the player
                EnemyAiController.canDealDamage = false;  // Prevent multiple hits from one attack
            }
        }
    }
}
