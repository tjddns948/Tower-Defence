using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShot: MonoBehaviour
{
    public GameObject bulletFactory;
    public Transform bulletSpawn;
    public float fireRate = 0.1f; //  �ʴ� �߻�Ǵ� �Ѿ��� ����
    private float nextFireTime = 0f; // ���� �Ѿ� �߻� �ð�


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

        // �Ѿ��� ����, �߻� ��ġ ��ġ
        GameObject bullet = Instantiate(bulletFactory, bulletSpawn.position, Quaternion.identity);

        // �Ѿ��� ������ �÷��̾ �ٶ󺸴� �������� ����
        bullet.transform.forward = shootDirection;

    }

}
