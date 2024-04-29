using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("BulletDamage")]
    public int norDamage;
    public int fireDamage;
    public int iceDamage;
    public int fDotDamage;
    [Header("EnemyHP")]
    public int maxEnemyHP = 100;
    public int enemyHP = 100;

    private bool isDotDamageActive = false;

    [Header("DestroyDelay")]
    public float desDelay = 3.0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        maxEnemyHP = enemyHP;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("NormalBullet"))
        {
            enemyHP -= norDamage;
            print(enemyHP);
        }
        if (other.gameObject.tag.Equals("FireBullet"))
        {
            enemyHP -= fireDamage;
            print(enemyHP);
        }
        if (other.gameObject.tag.Equals("IceBullet"))
        {
            enemyHP -= iceDamage;
            print(enemyHP);
        }
        if (other.gameObject.tag.Equals("FireDot"))
        {
            if (!isDotDamageActive)
            {
                StartCoroutine(DealDotDamage());
            }
        }
    }
    private IEnumerator DealDotDamage()
    {
        isDotDamageActive = true;
        for (int i = 0; i < 5; i++)
        {
            enemyHP -= fDotDamage;
            print(enemyHP);
            yield return new WaitForSeconds(1f);
        }
        isDotDamageActive = false;
    }
    
    void EnemyDie()
    {
        if (enemyHP <= 0)
        {
            animator.SetBool("IsDead", true);
            Destroy(gameObject, desDelay);
        }
    }


}
