using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float moveSpeed = 1f;
    private bool isIceEffectActive = false;
    public float iceEffectDuration = 3f;
    public float originalMoveSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIceEffectActive)
        {
            enemyMove();
        }
    }

    void enemyMove()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals ("IceExplosion"))
        {
            StartCoroutine(ApplyIceEffect());
        }
    }

    private IEnumerator ApplyIceEffect()
    {
        isIceEffectActive = true;
        moveSpeed -= 1f; 

        yield return new WaitForSeconds(iceEffectDuration);

        moveSpeed = originalMoveSpeed; 
        isIceEffectActive = false;
    }
}
