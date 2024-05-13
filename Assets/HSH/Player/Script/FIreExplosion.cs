using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreExplosion : MonoBehaviour
{

    float destroyTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

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

}
