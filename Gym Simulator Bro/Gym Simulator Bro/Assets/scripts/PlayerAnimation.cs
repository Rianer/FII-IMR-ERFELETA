using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Mirror")
        {
            playerAnimator.ResetTrigger("leftMirrorArea");
            playerAnimator.Play("metarig_001|Flex");
            Debug.Log("Player entered mirror collider");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.name == "Mirror")
        {
            playerAnimator.SetTrigger("leftMirrorArea");
        }
    }
}
