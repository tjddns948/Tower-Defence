using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreExplosion : MonoBehaviour
{
    GameObject enemyUI;
    int repeatCount = 5;
    int currentCount = 0;

    float destroyTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyUI = GameObject.Find("EnemyUI");
        StartCoroutine(MessageRepeat());
    }
    // Update is called once per frame
    void Update()
    {
        ExplosionDestroy();

    }
    void ExplosionDestroy()
    {
        // 이펙트 발생후 삭제 시간 
        destroyTime += Time.deltaTime;
        if (destroyTime >= 5.0f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator MessageRepeat()
    {
        while (currentCount < repeatCount)
        {
            yield return new WaitForSeconds(1f);
            if ( enemyUI != null && currentCount < repeatCount)
            {
                enemyUI.SendMessage("fireDotDamage");
                currentCount++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            currentCount = 0;
            StopAllCoroutines();
            StartCoroutine(MessageRepeat());
        }
    }
}
