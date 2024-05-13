using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot: MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform bulletSpawn;
    public float fireRate = 0.1f; //  초당 발사되는 총알의 개수
    private float nextFireTime = 0f; // 다음 총알 발사 시간


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            OneShotFire();  
            nextFireTime = Time.time + 1f / fireRate;
        }

    }


    void OneShotFire()
    {
        Vector3 shootDirection = transform.forward;

        // 총알을 생성, 발사 위치 배치
        GameObject bullet = Instantiate(bulletFactory, bulletSpawn.position, Quaternion.identity);

        // 총알의 방향을 플레이어가 바라보는 방향으로 설정
        bullet.transform.forward = shootDirection;

    }

}
