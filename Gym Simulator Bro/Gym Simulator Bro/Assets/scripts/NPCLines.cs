using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLines : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds_good;
    [SerializeField] AudioClip[] sounds_mean;
    [SerializeField] AudioClip[] sounds_fat;
    AudioSource myAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( true)
        {
            Sounds();
        }
    }
    void Sounds()
    {
        AudioClip clip = sounds_good[UnityEngine.Random.Range(0,sounds_good.Length)];
        myAudioSource.PlayOneShot(clip);
    }
}
