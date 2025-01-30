using UnityEngine;
using UnityEngine.AI;

public class ZombieAnim : MonoBehaviour
{
    [SerializeField] Animator zombieAnimator;
    NavMeshAgent agent;

    void Start()
    {
        zombieAnimator.SetBool("IsRunning", true);
        agent = GetComponent<NavMeshAgent>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!agent.isStopped)
            {
                agent.SetDestination(transform.position);
                agent.isStopped = true;
            }

            zombieAnimator.SetBool("IsAttacking", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombieAnimator.SetBool("IsAttacking", false);

            Invoke("ResumeAgent", 3f);
        }
    }

    void ResumeAgent()
    {
        agent.isStopped = false;
    }
}
