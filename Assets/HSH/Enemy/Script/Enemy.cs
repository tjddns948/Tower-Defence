using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool enemyDie = false;
    [System.NonSerialized]
    public int maxEnemyHP = 100;
    [System.NonSerialized]
    public int enemyHP = 100;

    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemyHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDie == true)
        {
            Destroy(gameObject);
        }

        enemyMove();

    }
    void enemyDestroy()
    {
        enemyDie = true;
    }
    void enemyMove()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
    public void DecreaseMoveSpeed(float amount, float duration)
    {
        moveSpeed -= amount;
        StartCoroutine(ResetMoveSpeed(amount, duration));
    }
    IEnumerator ResetMoveSpeed(float amount, float duration)
    {
        // duration 만큼 대기 
        yield return new WaitForSeconds(duration);

        moveSpeed += amount;
    }



}
