using System.Collections;
using Unity.VisualScripting;
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
        target = GameObject.FindGameObjectWithTag("CastleWall").transform;
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
        if (other.gameObject.CompareTag("CastleWall"))
        {
            animator.SetBool("IsAttackStart", true);
            transform.LookAt(target);
            navMeshAgent.avoidancePriority = 49;
        }
        if (other.gameObject.CompareTag("NormalBullet") || other.gameObject.CompareTag ("FireBullet"))
        {
            animator.SetBool("IsAttacked", true);
            Invoke("SetBoolAttackedFalse", 0.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("CastleWall"))
        {
            animator.SetBool("IsAttackStop", true);
            navMeshAgent.avoidancePriority = 50;
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsAttacked", false); 
        navMeshAgent.speed = 2f;
    }
    void SetBoolAttackedFalse()
    {
        animator.SetBool("IsAttacked", false);
    }
}