using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CamaraEffect : MonoBehaviour
{
    public Material camerMaterial;


    // Start is called before the first frame update
    void Start()
    {
     //   camerMaterial = new Material(Shader.Find("CSW/Blur"));
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, camerMaterial);



    }
   
}

