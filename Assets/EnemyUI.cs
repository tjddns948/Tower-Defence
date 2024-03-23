using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    bool PlayerAttack = false;

    [Header("HPImage")]
    public Image enemyHP;

    [Header("EnemyObj")]
    public GameObject enemyObj;

    Enemy e;
    // Start is called before the first frame update
    void Start()
    {
        e = enemyObj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAttack == true)
        {
            if (e.enemyHP > 0)
            {
                e.enemyHP--;
                enemyHP.fillAmount = (float)e.enemyHP / (float)e.maxEnemyHP;
                PlayerAttack = false;
            }
        }
        {
            if (e.enemyHP == 0)
            {
               if (enemyObj != null)
               {
                GameObject.Find("Enemy").SendMessage("enemyDestroy");
               }
            }

        }

    }
    void PlayerAttackHP()
    {
        if (!PlayerAttack)
        {
            PlayerAttack = true;
        }
    }
}
