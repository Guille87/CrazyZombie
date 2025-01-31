using UnityEngine;
using UnityEngine.AI;

public class ZombieAnim : MonoBehaviour
{
    [SerializeField] Animator zombieAnimator;
    [SerializeField] int attackDamage = 10;
    [SerializeField] float attackRange = 1.5f;
    [SerializeField] float attackAngle = 30f;

    Transform player;
    NavMeshAgent agent;
    bool isAttacking = false;

    void Start()
    {
        zombieAnimator.SetBool("IsRunning", true);
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    public void ApplyAttackDamage()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            player.SendMessage("ApplyDamage", attackDamage, SendMessageOptions.DontRequireReceiver);
        }
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
            isAttacking = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zombieAnimator.SetBool("IsAttacking", false);
            isAttacking = false;

            Invoke("ResumeAgent", 3f);
        }
    }

    void ResumeAgent()
    {
        agent.isStopped = false;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 leftRay = Quaternion.AngleAxis(-attackAngle, transform.up) * transform.forward;
        Vector3 rightRay = Quaternion.AngleAxis(attackAngle, transform.up) * transform.forward;

        Gizmos.DrawRay(transform.position, leftRay * attackRange);
        Gizmos.DrawRay(transform.position, rightRay * attackRange);
    }
}
