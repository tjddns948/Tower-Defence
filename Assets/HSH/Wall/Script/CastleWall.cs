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

    // 체력을 감소시키는 메서드
    private void Update()
    {
        
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "체력: " + currentHealth;
        }
    }
}
