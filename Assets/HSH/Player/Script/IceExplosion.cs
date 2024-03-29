using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceExplosion : MonoBehaviour
{
    public float slowAmount = 1f;
    public float slowDuration = 5f;

    float destroyTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 이펙트 발생후 삭제 시간 
        destroyTime += Time.deltaTime;
        if (destroyTime >= 2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // enemy가 충돌하면 슬로우
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Enemy enemyMove = other.GetComponent<Enemy>();
            if ( enemyMove != null)
            {
                enemyMove.DecreaseMoveSpeed(slowAmount, slowDuration);
            }
        }
    }
}
