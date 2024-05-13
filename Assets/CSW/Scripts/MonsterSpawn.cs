using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{

    public GameObject monsterPrefab; //몬스터 프리팹
    public Transform spawnPoint; //생성될 위치
    public float spawnInterval = 1f; // 몬스터 스폰 간격
    public int totalMonsterCount = 70; //총 몬스터 수

    private int currentMonsterCount = 0; // 생성된 몬스터 수

   
    void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, spawnInterval); // 일정간격으로 몬스터 생성 시작
    }

    void SpawnMonster()
    {
        if(currentMonsterCount >= totalMonsterCount)
        {
            //몬스터 모두 생성하면 스폰 중지
            CancelInvoke("SpawnMonster");
            return;

        }
        //몬스터 생성
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        currentMonsterCount++;
    }

}
