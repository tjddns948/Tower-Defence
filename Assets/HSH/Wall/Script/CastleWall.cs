using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleWall : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 
    public Text healthText;
    public Text gameOverText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        gameOverText.gameObject.SetActive(false);
    }

    // 체력을 감소시키는 메서드s
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
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthUI();
        if (currentHealth == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);    
    }
}
