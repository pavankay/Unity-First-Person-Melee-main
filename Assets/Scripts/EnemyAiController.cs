using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    public Transform player;
    public float AttackDistance = 5f;

    private NavMeshAgent m_agent;
    private Animator m_animator;
    private float m_distanceToPlayer;
    
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        m_distanceToPlayer = Vector3.Distance(m_agent.transform.position, player.position);
        if (m_distanceToPlayer < AttackDistance)
        {
            m_agent.isStopped = true;
            m_animator.SetBool("Attack", true);
        }
        else
        {
            m_agent.isStopped = false;
            m_animator.SetBool("Attack", false);
            m_agent.destination = player.position;
        }

    }

    void OnAnimatorMove()
    {
        if (m_animator.GetBool("Attack") == false)
        {
            //m_agent.speed = (m_animator.deltaPosition / Time.deltaTime).magnitude;
            m_agent.speed = 5f;
        }
    }
}
