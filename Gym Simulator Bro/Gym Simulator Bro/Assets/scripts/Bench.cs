using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bench : MonoBehaviour
{
    public GameObject bench;
    public GameObject xrOrigin;

    public float positionX = 0.0f;
    public float positionY = 0.0f;
    public float positionZ = 0.0f;


    public void sit()
    {
        xrOrigin.transform.position = bench.transform.position + new Vector3(positionX,positionY,positionZ);
        xrOrigin.transform.rotation = bench.transform.rotation;
    }
}
