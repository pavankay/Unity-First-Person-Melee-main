using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    public Transform player;
    public float AttackDistance = 1f;
    public float damageDelay = 0.2f;  // Time delay before the damage can be applied

    private NavMeshAgent m_agent;
    private Animator m_animator;
    private float m_distanceToPlayer;

    public static bool isAttacking = false;
    public static bool canDealDamage = false;  // This controls when damage can be applied

    private float attackTimer = 0f;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_distanceToPlayer = Vector3.Distance(m_agent.transform.position, player.position);

        if (m_distanceToPlayer < AttackDistance)
        {
            m_agent.isStopped = true;
            isAttacking = true;
            m_animator.SetBool("Attack", true);

            attackTimer += Time.deltaTime;  // Start counting time since attack started

            if (attackTimer >= damageDelay)
            {
                canDealDamage = true;  // Allow damage after the delay
            }
        }
        else
        {
            m_agent.isStopped = false;
            isAttacking = false;
            canDealDamage = false;  // Reset damage ability when not attacking
            attackTimer = 0f;  // Reset the timer
            m_animator.SetBool("Attack", false);
            m_agent.destination = player.position;
        }
    }

    void OnAnimatorMove()
    {
        if (m_animator.GetBool("Attack") == false)
        {
            m_agent.speed = (m_animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}
