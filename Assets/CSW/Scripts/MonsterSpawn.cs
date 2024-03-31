using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{

    public GameObject monsterPrefab; //���� ������
    public Transform spawnPoint; //������ ��ġ
    public float spawnInterval = 1f; // ���� ���� ����
    public int totalMonsterCount = 70; //�� ���� ��

    private int currentMonsterCount = 0; // ������ ���� ��

   
    void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, spawnInterval); // ������������ ���� ���� ����
    }

    void SpawnMonster()
    {
        if(currentMonsterCount >= totalMonsterCount)
        {
            //���� ��� �����ϸ� ���� ����
            CancelInvoke("SpawnMonster");
            return;

        }
        //���� ����
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
        currentMonsterCount++;
    }

}
