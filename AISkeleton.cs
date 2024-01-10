using UnityEngine;
using UnityEngine.AI;

public class AISkeleton : MonoBehaviour
{
    public Transform target; // Player's transform

    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Set the initial destination to the player's position
        SetDestinationToPlayer();
    }

    void Update()
    {
        // Update the destination to follow the player
        SetDestinationToPlayer();
    }

    void SetDestinationToPlayer()
    {
        if (target != null)
        {
            // Set the destination to the player's position
            navMeshAgent.SetDestination(target.position);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var healthComponent = collision.gameObject.GetComponent<HealthManager>();
        if (collision.gameObject.CompareTag("Player"))
        {
    
            healthComponent.TakeDamage(1);
            
        }
    }
}
