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
    private CastleWall castleWall;
    public float attackInterval = 1.0f;
    public int damageAmount = 1;
    private bool isFrozen = false;

    void Start()
    {
        GameObject castleWallObject = GameObject.FindGameObjectWithTag("CastleWall");
        if (castleWallObject != null)
        {
            target = castleWallObject.transform;
            castleWall = castleWallObject.GetComponent<CastleWall>();
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            //print(target.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("IceExplosion"))
        {
            animator.SetBool("IsAttacked", true);
            isFrozen = true;
            navMeshAgent.speed = 0f;
            StartCoroutine(ResumeAfterDelay(FreezeTime));
        }
        if (other.gameObject.CompareTag("CastleWall"))
        {
            animator.SetBool("IsAttackStart", true);
            transform.LookAt(target);
            navMeshAgent.avoidancePriority = 49;
            StartCoroutine(AttackCastle());
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
            StopCoroutine(AttackCastle());
        }
    }

    IEnumerator ResumeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("IsAttacked", false); 
        navMeshAgent.speed = 2f;
        isFrozen = false;
    }
    void SetBoolAttackedFalse()
    {
        animator.SetBool("IsAttacked", false);
    }
    IEnumerator AttackCastle()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            if (castleWall != null)
            {
                if (isFrozen == true)
                {
                    damageAmount = 0;
                }
                else
                {
                    damageAmount = 1;
                    castleWall.TakeDamage(damageAmount);
                }
            }
        }
    }
}