using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject explosionEffect;

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
        if (other.gameObject.tag.Equals("Enemy"))
        {
            GameObject.Find("EnemyUI").SendMessage("PlayerAttackHP");
            Destroy(gameObject);
            GameObject explosion = Instantiate (explosionEffect);
            explosion.transform.position = transform.position;
        }
        if (other.gameObject.tag.Equals("Floor"))
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionEffect);
            explosion.transform.position = transform.position;
        }
    }
}
