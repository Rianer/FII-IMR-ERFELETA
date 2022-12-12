using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    
     public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player Hand")
        {
            PlayerController.Instance.RespawnPlayer();
            Debug.Log("A intrat aici");
        }
    }
    void Start(){}
    void Update()
    {
    }
}
