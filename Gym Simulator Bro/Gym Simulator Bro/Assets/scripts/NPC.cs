using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] GameObject npc;
    [SerializeField] int health;
    [SerializeField] int damage;
    private int start_money;
    private int start_health;
    private int start_damage;
    AudioSource myAudioSource;


    public bool isSpawned = true;
    void Start()
    {
        start_damage = damage;
        start_money = money;
        start_health= health;
        myAudioSource = GetComponent<AudioSource>();
     
    }

    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player Hand")
        {
            myAudioSource.Play(0);
            TakeDamage(StatsController.Instance.damage);
            DealDamage(StatsController.Instance);

            if (health <= 0)
            {
                Debug.Log("Won fight");
                StatsController.Instance.IncreaseMoney(money);
                NPCsSpawner.Instance.start = DateTime.Now;
                ResetStats();
                npc.SetActive(false);
               
            }
            if (StatsController.Instance.health<= 0) 
            {
                Debug.Log("Lost fight");
                PlayerController.Instance.RespawnPlayer();
            }
           
        }

        if(collider.tag == "Throwable" || collider.tag == "Liftable")
        {
            myAudioSource.Play(0);
            TakeDamage(100); //damage obiecte hardcodat
            if (health <= 0)
            {
                Debug.Log("Won fight");
                StatsController.Instance.IncreaseMoney(money);
                NPCsSpawner.Instance.start = DateTime.Now;
                ResetStats();
                npc.SetActive(false);
            }
        }
    }

    public void TakeDamage(int playerDamage)
    {
        this.health = this.health - playerDamage;
        Debug.Log("npc health: " + this.health.ToString());
    }

    public void DealDamage(StatsController instance)
    {
        instance.TakeDamage(damage);
        Debug.Log("player health: " + instance.health.ToString());
    }
  
    public void ResetStats()
    {
        damage = start_damage;
        health= start_health;
        money= start_money;
    }
}
