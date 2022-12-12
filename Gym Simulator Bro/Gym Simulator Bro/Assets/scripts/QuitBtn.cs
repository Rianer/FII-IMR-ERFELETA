using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
      public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player Hand")
        {
                Debug.Log("A intrat aici quit");
            	Application.Quit();
        }
    }
    void Start()
    {}
    void Update()
    {}
}
