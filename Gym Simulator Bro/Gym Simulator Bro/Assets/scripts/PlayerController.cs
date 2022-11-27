using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject player;
    DateTime start;

    void Awake()
    {
        start = DateTime.Now;
        Instance = this;
    }

   
    void Update()
    {
        CheckTime();
    }

    public void RespawnPlayer()
    {
        player.transform.position = spawnPoint.position;
    }

    public void CheckTime()
    {
        if((DateTime.Now - start).TotalSeconds > 10)
        {
            StatsController.Instance.DecreaseHunger();
            start = DateTime.Now;
        }
    }
}
