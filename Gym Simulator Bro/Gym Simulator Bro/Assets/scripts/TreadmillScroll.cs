using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillScroll : MonoBehaviour
{

    public float scrollX = 0f;
    public float scrollY = 0.5f;
    public Material scrollableMaterial;


    // Update is called once per frame
    void Update()
    {
        float offSetX = Time.time * scrollX;
        float offSetY = Time.time * scrollY;
        scrollableMaterial.mainTextureOffset = new Vector2(offSetX, offSetY);
    }
}
