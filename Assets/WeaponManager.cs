using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float switchDelay = 1f;
    public GameObject[] weapon;

    private int index = 0;
    private bool isSwitching = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeWeapon();
    }

    // Update is called once per frame
    void Update()
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
}
