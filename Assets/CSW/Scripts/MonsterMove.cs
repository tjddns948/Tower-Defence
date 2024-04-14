using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform target;
    private Animator animator;
    public float FreezeTime = 3.0f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IceExplosion"))
        {
            animator.SetBool("IsAttacked", true);
            navMeshAgent.speed = 0f;
            StartCoroutine(ResumeAfterDelay(FreezeTime));
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsAttacked", false); 
        navMeshAgent.speed = 2f;
    }
}