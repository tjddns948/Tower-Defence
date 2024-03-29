using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    bool nPlayerAttack = false;
    bool fPlayerAttack = false;
    bool iPlayerAttack = false;
    bool fireDotAttack = false;

    [Header("HPImage")]
    public Image enemyHP;

    [Header("EnemyObj")]
    public GameObject enemyObj;
    [Header("BulletDamage")]
    public int norDamage;
    public int fireDamage;
    public int iceDamage;
    public int fDotDamage;


    Enemy e;
    // Start is called before the first frame update
    void Start()
    {
        e = enemyObj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        ReceiveDamage();

    }
    void ReceiveDamage()
    {
        if (nPlayerAttack == true )
        {
            if (e.enemyHP > 0)
            {
                e.enemyHP -= norDamage;
                enemyHP.fillAmount = (float)e.enemyHP / (float)e.maxEnemyHP;
                nPlayerAttack = false;
            }
            if (e.enemyHP <= 0)
            {
                if (enemyObj != null)
                {
                    GameObject.Find("Enemy").SendMessage("enemyDestroy");
                }
            }
        }
        else if (fPlayerAttack == true )
        {
            if (e.enemyHP > 0)
            {
                e.enemyHP -= fireDamage;
                enemyHP.fillAmount = (float)e.enemyHP / (float)e.maxEnemyHP;
                fPlayerAttack = false;
            }
            if (e.enemyHP <= 0)
            {
                if (enemyObj != null)
                {
                    GameObject.Find("Enemy").SendMessage("enemyDestroy");
                }
            }
        }
        else if (iPlayerAttack == true)
        {
            if (e.enemyHP > 0)
            {
                e.enemyHP -= iceDamage;
                enemyHP.fillAmount = (float)e.enemyHP / (float)e.maxEnemyHP;
                iPlayerAttack = false;
            }
            if (e.enemyHP <= 0)
            {
                if (enemyObj != null)
                {
                    GameObject.Find("Enemy").SendMessage("enemyDestroy");
                }
            }
        }
        else if (fireDotAttack == true)
        {
            if (e.enemyHP > 0)
            {
                e.enemyHP -= fDotDamage;
                enemyHP.fillAmount = (float)e.enemyHP / (float)e.maxEnemyHP;
                fireDotAttack = false;
            }
            if (e.enemyHP <= 0)
            {
                if (enemyObj != null)
                {
                    GameObject.Find("Enemy").SendMessage("enemyDestroy");
                }
            }
        }
    }
        

    void nPlayerAttackHP()
    {
        if (!nPlayerAttack)
        {
            nPlayerAttack = true;
        }
    }
    void fPlayerAttackHP()
    {
        if (!fPlayerAttack)
        {
            fPlayerAttack = true;
        }
    }
    void iPlayerAttackHP()
    {
        if (!iPlayerAttack)
        {
            iPlayerAttack = true;
        }
    }
    void fireDotDamage()
    {
        if (!fireDotAttack)
        {
            fireDotAttack = true;
        }
    }
}

