using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PlayerShotNormal: MonoBehaviour
{
    public Cam cShake;
    public GameObject bulletFactory;
    public GameObject magicCircle;
    public Transform bulletSpawn;
    public float fireRate = 0.1f; // �ʴ� �߻�Ǵ� �Ѿ��� ����
    private float nextFireTime = 0f; // ���� �Ѿ� �߻� �ð�
    Renderer magicCircleRenderer;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        magicCircleRenderer = magicCircle.GetComponent<Renderer>();
        SetMagicCircleAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && magicCircleRenderer.material.color.a <= 1)
        {
            StartCoroutine(FadeInMagicCircle());
        }
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            OneShotFire();
            cShake.CamShake();
            nextFireTime = Time.time + 1f / fireRate;
        }
        if (Input.GetMouseButtonUp(0) && magicCircleRenderer.material.color.a > 0)
        {
            StartCoroutine(FadeOutMagicCircle());
        }
    }

    void OneShotFire()
    {
        Vector3 shootDirection = transform.forward;

        // �Ѿ��� ����, �߻� ��ġ ��ġ
        GameObject bullet = Instantiate(bulletFactory, bulletSpawn.position, Quaternion.identity);

        // �Ѿ��� ������ �÷��̾ �ٶ󺸴� �������� ����
        bullet.transform.forward = shootDirection;

        audioSource.Play();
    }

    IEnumerator FadeInMagicCircle()
    {
        float alpha = 0f;
        while (alpha <= 1)
        {
            alpha += 0.1f;
            SetMagicCircleAlpha(alpha);
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeOutMagicCircle()
    {
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= 0.1f;
            SetMagicCircleAlpha(alpha);
            yield return new WaitForSeconds(0.02f);
        }
    }

    void SetMagicCircleAlpha(float alpha)
    {
        Color newColor = magicCircleRenderer.material.color;
        newColor.a = alpha;
        magicCircleRenderer.material.color = newColor;
    }
}
