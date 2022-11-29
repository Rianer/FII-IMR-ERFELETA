using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private LayerMask groundLayer;
    private Ray downRay;
    void Start()
    {
        distance = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        downRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(downRay, out hit, 50f, groundLayer))
        {
            //Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.yellow);
            distance = hit.distance;
        }
    }
}
