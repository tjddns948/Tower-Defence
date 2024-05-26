using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public Text enemyCountText;
    private int enemyCount;

    public Text gameTimeCountText;
    private float gameTime = 0.0f;
    private bool isGameRun = true;
    GameObject[] enemies;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);    
        isGameRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCounter();
        PlayTimeCounter();
    }
    
    void EnemyCounter()
    {
        if (isGameRun == true)
        {
            enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            int enemyCount = enemies.Length;
            enemyCountText.text = "남은 적: " + enemyCount.ToString();
        }
        if(isGameRun == false)
        {
            WinGame();
        }
    }
    void PlayTimeCounter()
    {
        if (isGameRun == true)
        {
            gameTime += Time.deltaTime;
            gameTimeCountText.text = "시간: " + gameTime.ToString("F2");
            if (gameTime >= 10.0f && enemies.Length == 0)
            {
                isGameRun = false;
                gameTimeCountText.text += " - 정지";
            }
        }
    }

    void WinGame()
    {
        winText.gameObject.SetActive(true);
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
