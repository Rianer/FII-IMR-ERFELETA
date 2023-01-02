using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player Hand")
        {
            StatsController.Instance.IncreaseRespect(1);
            StatsController.Instance.DecreaseStamina(1);
            Debug.Log("punched bag");
        }
    }
}
