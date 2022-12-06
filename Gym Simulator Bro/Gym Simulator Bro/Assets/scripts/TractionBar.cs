using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractionBar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject xrOrigin;
    public GameObject bar;

    public void teleport()
    {
        Debug.Log("function teleport called");
        xrOrigin.transform.position = bar.transform.position;
    }
}
