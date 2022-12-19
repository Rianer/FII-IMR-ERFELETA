using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCLines : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds_good;
    [SerializeField] AudioClip[] sounds_mean;
    [SerializeField] AudioClip[] sounds_fat;
    [SerializeField] AudioClip[] no_money;
    [SerializeField] AudioClip[] low_stamina;
    [SerializeField] AudioClip[] low_hunger;

    AudioSource myAudioSource;
    DateTime start;
    DateTime startMoney;
    DateTime startHunger;
    DateTime startStamina;


     void Awake()
    {
        start = DateTime.Now;
        startMoney = DateTime.Now;
        startHunger = DateTime.Now;
        startStamina = DateTime.Now;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime(); 
        CheckHunger();
        CheckMoney();
        CheckStamina();
       
    }

    void Sounds()
    {
        int respect=StatsController.Instance.GetRespect();
        if(respect<50)
        {   
             AudioClip clip = sounds_mean[UnityEngine.Random.Range(0,sounds_mean.Length)];
             myAudioSource.PlayOneShot(clip);
        }
        else 
        {
            AudioClip clip = sounds_good[UnityEngine.Random.Range(0,sounds_good.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
    
     void Hunger()
    {
        int hunger=StatsController.Instance.GetHunger();
        if(hunger<40)
        {   
             AudioClip clip = low_hunger[UnityEngine.Random.Range(0,low_hunger.Length)];
             myAudioSource.PlayOneShot(clip);
        }
    }

     void Stamina()
    {
        int stamina=StatsController.Instance.GetStamina();
        if(stamina<40)
        {   
             AudioClip clip = low_stamina[UnityEngine.Random.Range(0,low_stamina.Length)];
             myAudioSource.PlayOneShot(clip);
        }
    }

     void Money()
    {
        int money=StatsController.Instance.GetMoney();
         if(money<40)
        {   
             AudioClip clip = no_money[UnityEngine.Random.Range(0,no_money.Length)];
             myAudioSource.PlayOneShot(clip);
        }
    }

     public void CheckTime()
    {
        if((DateTime.Now - start).TotalSeconds > 10)
        {   
            Sounds();
            start = DateTime.Now;
        }
    }
    public void CheckHunger()
    {
        if((DateTime.Now - startHunger).TotalSeconds > 20)
        {   
            Hunger();
            startHunger = DateTime.Now;
        }
    }
    public void CheckStamina()
    {
        if((DateTime.Now - startStamina).TotalSeconds > 15)
        {   
            Stamina();
            startStamina = DateTime.Now;
        }
    }
    public void CheckMoney()
    {
         if((DateTime.Now - startMoney).TotalSeconds > 30)
        {   
            Money();
            startMoney = DateTime.Now;
        }
    }
}
