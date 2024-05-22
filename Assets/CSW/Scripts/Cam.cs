using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    bool bShake = false;
    Vector3 camOrigin = Vector3.zero;   
    // Start is called before the first frame update
    void Start()
    {
        camOrigin = transform.localPosition;
    }


    float currentTime = 0.0f;
    public float shakeTime = 1.0f;

    float i = 0.01f;
    public float shakeSize = 0.02f;
    // Update is called once per frame
    void Update()
    {
        i = i + 0.01f;
        RenderSettings.skybox.SetFloat("_Rotation", i);
        if (bShake == true)
        {
            transform.localPosition = camOrigin + Random.onUnitSphere * shakeSize;
            currentTime += Time.deltaTime;
            if (currentTime > shakeTime)
            {
                transform .localPosition = camOrigin;    
                bShake = false;
                currentTime = 0.0f;
            }
        }
    }

    public void CamShake()
    {
        bShake = true;  
    }

}
