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
        // ����Ʈ �߻��� ���� �ð� 
        destroyTime += Time.deltaTime;
        if (destroyTime >= 2f)
        {
            Destroy(gameObject);
        }
    }
}
