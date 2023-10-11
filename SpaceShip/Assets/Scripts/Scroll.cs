using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float speed = 0.1f;
    private float scrollX;
    private MeshRenderer meshRenderer;

    void Scroll(){
        scrollX = Time.time * speed;
        Vector2 offSet = new Vector2(scrollX, 0f);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offSet);
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    void Update(){
        Scroll();
    }
}
