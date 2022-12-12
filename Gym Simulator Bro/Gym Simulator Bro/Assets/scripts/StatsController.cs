using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    int hunger = 100;
    int respect = 51;
    int stamina = 100;
    int money = 100;
    public int health = 100;
    [SerializeField] public int damage;


    public static StatsController Instance { get; private set; }
    [SerializeField] GameObject hungerText;
    [SerializeField] GameObject respectText;
    [SerializeField] GameObject staminaText;
    [SerializeField] GameObject moneyText;
    
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
        stamina = stamina - amount;
    }

    public void IncreaseStamina(int amount)
    {
        stamina = stamina+ amount;
    }
    public void DecreaseMoney(int amount)
    {
        money = money - amount;
    }

    public void IncreaseMoney(int amount)
    {
        money = money + amount;
    }
    
    public void DecreaseHunger()
    {
        hunger = hunger - 5;
    }

    public int GetMoney()
    {
        return money;
    }
    
    public int GetRespect()
    {
        return respect;
    }

    public void TakeDamage(int npcDamage)
    {
        health = health - npcDamage;
    }

    public void DisplayStatus()
    {
        hungerText.GetComponent<Text>().text = hunger.ToString()+"/100";
        respectText.GetComponent<Text>().text = respect.ToString() + "/100";
        staminaText.GetComponent<Text>().text = stamina.ToString() + "/100";
        moneyText.GetComponent<Text>().text = money.ToString() + "/100";
    }

}
