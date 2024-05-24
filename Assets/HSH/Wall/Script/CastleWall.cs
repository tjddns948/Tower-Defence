using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleWall : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 
    public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // ü���� ���ҽ�Ű�� �޼���
    private void Update()
    {
        
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "ü��: " + currentHealth;
        }
    }
}
