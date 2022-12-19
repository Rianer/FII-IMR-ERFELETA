using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
     public void Respawn()
    {
       
        PlayerController.Instance.RespawnPlayer();
        
    }
    void Start(){}
    void Update()
    {
    }
}
