using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineTriggers : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;
    [SerializeField]
    int price;
    // Start is called before the first frame update
    bool locked = false;
   
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(name + " to " + other.name);

        if (StatsController.Instance.GetMoney() >= price)
        {
            if (other.name.EndsWith("hand") && locked == false)
            {
                locked = true;
                GameObject foodItem = Instantiate(objectToSpawn, GetComponentInParent<Transform>().position + new Vector3(0, 0, -1), transform.rotation);
                StartCoroutine(unlock());
            }
            StatsController.Instance.DecreaseMoney(price);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    IEnumerator unlock()
    {
        yield return new WaitForSeconds(0.5f);
        locked = false;
    }
}
