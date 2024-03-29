using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;


    }
    private void OnTriggerEnter(Collider other)
    {
        // 에너미에 맞으면
        if (other.gameObject.tag.Equals ("Enemy"))
        {
            GameObject.Find("EnemyUI").SendMessage("nPlayerAttackHP");
            Destroy(gameObject);
        }
    }

}
