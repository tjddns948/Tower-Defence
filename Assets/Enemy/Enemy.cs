using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool enemyDie = false;
    [System.NonSerialized]
    public int maxEnemyHP = 5;
    [System.NonSerialized]
    public int enemyHP = 5;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemyHP = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enemyDestroy()
    {
        Destroy (gameObject);
    }
}
