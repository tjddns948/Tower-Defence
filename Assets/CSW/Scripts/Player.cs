using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5f;
    public float dashspeed = 10f;
    public float dashDuration = 0.5f;
    float hAxis;
    float vAxis;

    Vector3 moveVec;

    private float originalMoveSpeed;
    private bool isDashing = false;

    void Start()
    {
        originalMoveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
        
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
    }

    IEnumerator Dash()
    {
        isDashing = true;
        speed = dashspeed;

        yield return new WaitForSeconds(dashDuration);

        speed = originalMoveSpeed;
        isDashing = false;
    }
}
