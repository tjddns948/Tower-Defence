using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("NormalBullet"))
        {
            Destroy (other.gameObject);
        }
        if (other.gameObject.tag.Equals("IceBullet"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("FireBullet"))
        {
            Destroy(other.gameObject);
        }

    }
}
