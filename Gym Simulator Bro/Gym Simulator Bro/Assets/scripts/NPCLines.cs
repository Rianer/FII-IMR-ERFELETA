using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCLines : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds_good;
    [SerializeField] AudioClip[] sounds_mean;
    [SerializeField] AudioClip[] sounds_fat;
    AudioSource myAudioSource;
    DateTime start;



     void Awake()
    {
        start = DateTime.Now;
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
    
     public void CheckTime()
    {
        if((DateTime.Now - start).TotalSeconds > 10)
        {   
            Sounds();
            start = DateTime.Now;
        }
    }
}
