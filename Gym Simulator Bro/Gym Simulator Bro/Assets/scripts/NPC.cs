using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] int money;
    [SerializeField] GameObject npc;
    [SerializeField] int health;
    [SerializeField] int damage;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player Hand")
        {
            TakeDamage(StatsController.Instance.damage);
            DealDamage(StatsController.Instance);

            if (health <= 0)
            {
                Debug.Log("Won fight");
                StatsController.Instance.IncreaseMoney(money);
                Destroy(npc);
            }
            if (StatsController.Instance.health<= 0) 
            {
                Debug.Log("Lost fight");
                PlayerController.Instance.RespawnPlayer();
            }
        }

        if(collider.tag == "Throwable" || collider.tag == "Liftable")
        {
            TakeDamage(100); //damage obiecte hardcodat
            if (health <= 0)
            {
                Debug.Log("Won fight");
                StatsController.Instance.IncreaseMoney(money);
                Destroy(npc);
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
}
