using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
