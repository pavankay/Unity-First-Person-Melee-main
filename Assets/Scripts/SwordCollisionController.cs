using UnityEngine;

public class SwordCollisionController : MonoBehaviour
{
    public int damageAmount = 10;  // Amount of damage the sword deals

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Check if the sword hit the player
        {


            PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
            EnemyAiController enemy = GetComponentInParent<EnemyAiController>(); // Get enemy AI controller from parent object

            if (playerHealth != null && enemy != null)
            {

                // Only deal damage if this specific enemy is attacking and allowed to deal damage
                if (enemy.IsAttacking() && enemy.CanDealDamage())
                {
 
                    playerHealth.TakeDamage(damageAmount);  // Apply damage to the player
                    enemy.ResetDamage();  // Prevent multiple hits from one attack
                }
            }
        }
    }
}
