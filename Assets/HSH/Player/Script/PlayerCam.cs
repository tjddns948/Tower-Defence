using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCam : MonoBehaviour
{
    Rigidbody rb;

    [Header("Rotate")]
    float yRotation;
    float xRotation;
    Camera cam;

    [Range(0, 1600)]
    public float mouseSpeed;


    [Header("Move")]
    public float moveSpeed;
    float h;
    float v;

    [Header("Dash")]
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    private float originalMoveSpeed;
    private bool isDashing = false;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;                     
        rb = GetComponent<Rigidbody>();             
        rb.freezeRotation = true;                   
        cam = Camera.main;
        originalMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();

        // Dash 입력 감지
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }
    void Rotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;

        yRotation += mouseX;    
        xRotation -= mouseY;    

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); 
        transform.rotation = Quaternion.Euler(0, yRotation, 0);             
    }
    void Move()
    {
        h = Input.GetAxisRaw("Horizontal"); 
        v = Input.GetAxisRaw("Vertical");   
        Vector3 moveVec = transform.forward * v + transform.right * h;
        transform.position += moveVec.normalized * moveSpeed * Time.deltaTime;
    }
    IEnumerator Dash()
    {
        isDashing = true;
        moveSpeed = dashSpeed;
        audioSource.Play();

        yield return new WaitForSeconds(dashDuration);

        moveSpeed = originalMoveSpeed;
        isDashing = false;
    }

}
