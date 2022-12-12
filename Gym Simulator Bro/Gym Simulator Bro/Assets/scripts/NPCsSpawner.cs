using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCsSpawner : MonoBehaviour
{
    [SerializeField] GameObject npc1;
    [SerializeField] GameObject npc2;
    [SerializeField] GameObject npc3;
    public DateTime start;
    public static NPCsSpawner Instance;
    public void Awake()
    {
        start = DateTime.Now;
        Instance = this;
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        CheckTime();
    }
    public void CheckTime()
    {
        if ((DateTime.Now - start).TotalSeconds > 10)
        {
            if (npc1.active == false)
            {
                npc1.SetActive(true);
            }
            if (npc2.active == false)
            {
                npc2.SetActive(true);
            }
            if (npc3.active == false)
            {
                npc3.SetActive(true);
            }
        }
       
    }
}
