using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatsController : MonoBehaviour
{
    int hunger = 80;
    int respect = 0;
    int stamina = 50;
    int money = 100;
    public int health = 100;
    [SerializeField] public int damage;


    public static StatsController Instance { get; private set; }
    [SerializeField] TextMeshProUGUI hungerText;
    [SerializeField] TextMeshProUGUI respectText;
    [SerializeField] TextMeshProUGUI staminaText;
    [SerializeField] TextMeshProUGUI moneyText;
    
    void Awake()
    {
        Instance= this;
        
    }

    void Update()
    {
        CheckHunger();
        CheckStamina();
        DisplayStatus();
    }

    public void CheckStamina()
    {
        bool showStaminaWarning = false;
        if(stamina < 10 && showStaminaWarning == false)
        {
            showStaminaWarning = true;
            Debug.Log("Low stamina!");
        }
        if(stamina >= 10)
        {
            showStaminaWarning = false;
        }
    }
    public void CheckHunger()
    {
        bool showHungerWarning = false;
        if (hunger < 10 && showHungerWarning == false)
        {
            showHungerWarning = true;
            Debug.Log("Low hunger!");
        }
        if (hunger >= 10)
        {
            showHungerWarning = false;
        }

    }

    
    public void DecreaseStamina(int amount)
    {
        if (stamina - amount >= 0)
            stamina = stamina - amount;
        else
            stamina = 0;
    }

    public void IncreaseStamina(int amount)
    {
        if (stamina + amount <= 100)
            stamina = stamina + amount;
        else
            stamina = 100;
    }
    public void DecreaseMoney(int amount)
    {
        money = money - amount;
    }

    public void IncreaseMoney(int amount)
    {
        money = money + amount;
    }

    public void IncreaseHunger(int amount)
    {
        if (hunger + amount <= 100)
            hunger = hunger + amount;
        else
            hunger = 100;
    }

     public void IncreaseRespect(int amount)
     {
        if (respect + amount <= 100)
            respect = respect + amount;
        else
            respect = 100;
     }

    public void DecreaseHunger(int amount)
    {
        if (hunger - amount >= 0)
            hunger = hunger - amount;
        else
            hunger = 0;
    }

    public int GetMoney()
    {
        return money;
    }
    
    public int GetRespect()
    {
        return respect;
    }

    public int GetHunger()
    {
        return hunger;
    }

    public int GetStamina()
    {
        return stamina;
    }

    public void TakeDamage(int npcDamage)
    {
        health = health - npcDamage;
    }

    public void DisplayStatus()
    {
        hungerText.text = hunger.ToString()+"/100";
        respectText.text = respect.ToString() + "/100";
        staminaText.text = stamina.ToString() + "/100";
        moneyText.text = money.ToString();
    }

}
