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
        // ����Ʈ �߻��� ���� �ð� 
        destroyTime += Time.deltaTime;
        if (destroyTime >= 2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // enemy�� �浹�ϸ� ���ӵ�����
        
    }
}
