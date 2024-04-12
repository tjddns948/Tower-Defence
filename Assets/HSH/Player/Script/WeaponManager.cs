using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float switchDelay = 1f;
    public GameObject[] weapon;

    private int index = 0;
    private bool isSwitching = false;

    [Header("NormalWeapon")]
    public UnityEngine.UI.Image norImage;
    public GameObject NormalWeapon;
    public float ncurrentCool = 5.0f;
    public float nmaxCool = 5.0f;
    public float NormalRate = 0.1f;
    private float nextNormalTime = 0f;

    [Header("IceWeapon")]
    public UnityEngine.UI.Image iceImage;
    public GameObject IceWeapon;
    public float icurrentCool = 5.0f;
    public float imaxCool = 5.0f;
    public float iceRate = 0.1f;
    private float nexticeTime = 0f;

    [Header("FireWeapon")]
    public UnityEngine.UI.Image fireImage;
    public GameObject FireWeapon;
    public float fcurrentCool = 5.0f;
    public float fmaxCool = 5.0f;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    [Header("SelectImage")]
    public GameObject Selice;
    public GameObject SelFire;
    public GameObject SelNor;

    // Start is called before the first frame update
    void Start()
    {
        SelNor.SetActive(true);
        SelFire.SetActive(false);
        Selice.SetActive(false);

        InitializeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        NumberWeaponChange();
        WheelWeaponChange();
        DetectWeaponChange();
    }
    private void InitializeWeapon()
    {
        // 0번 기본무기만 시작시 활성화 
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }
        weapon[0].SetActive(true);
        index = 0;
    }

    private IEnumerator SwitchDelay(int newIndex)
    {
        isSwitching = true;
        SwitchWeapons(newIndex);
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
    }

    private void SwitchWeapons(int newIndex)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            weapon[i].SetActive(false);
        }
        weapon[newIndex].SetActive(true);
    }

    IEnumerator iceCoolTime()
    {
        while (icurrentCool > 0.0f)
        {
            icurrentCool -= Time.deltaTime;
            iceImage.fillAmount = icurrentCool / imaxCool;
            yield return new WaitForFixedUpdate();
        }
        if (icurrentCool <= 0.0f)
        {
            icurrentCool = imaxCool;
            iceImage.fillAmount = icurrentCool / imaxCool;

        }
    }
    IEnumerator FireCoolTime()
    {
        while (fcurrentCool > 0.0f)
        {
            fcurrentCool -= Time.deltaTime;
            fireImage.fillAmount = fcurrentCool / fmaxCool;
            yield return new WaitForFixedUpdate();
        }
        if (fcurrentCool <= 0.0f)
        {
            fcurrentCool = fmaxCool;
            fireImage.fillAmount = fcurrentCool / fmaxCool;

        }
    }
    IEnumerator NormalCoolTime()
    {
        while (ncurrentCool > 0.0f)
        {
            ncurrentCool -= Time.deltaTime;
            norImage.fillAmount = ncurrentCool / nmaxCool;
            yield return new WaitForFixedUpdate();
        }
        if (ncurrentCool <= 0.0f)
        {
            ncurrentCool = nmaxCool;
            norImage.fillAmount = ncurrentCool / nmaxCool;

        }
    }
    void DetectWeaponChange()
    {
        if (NormalWeapon.activeSelf == true)
        {
            SelNor.SetActive(true);
            SelFire.SetActive(false);
            Selice.SetActive(false);

            if (Input.GetMouseButton(0) && Time.time >= nextNormalTime)
            {
                StartCoroutine(NormalCoolTime());
                nextNormalTime = Time.time + 1f / NormalRate;
            }
        }
        if (FireWeapon.activeSelf == true)
        {
            SelNor.SetActive(false);
            SelFire.SetActive(true);
            Selice.SetActive(false);
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                StartCoroutine(FireCoolTime());
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        if (IceWeapon.activeSelf == true)
        {
            SelNor.SetActive(false);
            SelFire.SetActive(false);
            Selice.SetActive(true);
            if (Input.GetMouseButton(0) && Time.time >= nexticeTime)
            {
                StartCoroutine(iceCoolTime());
                nexticeTime = Time.time + 1f / iceRate;
            }
        }
    }
    void NumberWeaponChange()
    {
        // 키보드로 무기 변경
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isSwitching)
        {
            index = 0;
            StartCoroutine(SwitchDelay(index));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !isSwitching)
        {
            index = 1;
            StartCoroutine(SwitchDelay(index));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !isSwitching)
        {
            index = 2;
            StartCoroutine(SwitchDelay(index));
        }
    }
    void WheelWeaponChange()
    {
        // 휠 무기변경
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
        {
            index++;
            if (index >= weapon.Length)
                index = 0;
            StartCoroutine(SwitchDelay(index));
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
        {
            index--;
            if (index < 0)
                index = weapon.Length - 1;
            StartCoroutine(SwitchDelay(index));
        }
    }
}
