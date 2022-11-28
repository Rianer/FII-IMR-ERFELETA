using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RadioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] songs;
    [SerializeField]
    AudioClip radioNoise;
    Random rand = new Random();
    AudioSource audioSource;
    bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(initialLock());
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(playNextSong());
    }

    IEnumerator initialLock()
    {
        yield return new WaitForSeconds(3);
        locked = false;
    }

    IEnumerator playNextSong()
    {
        if(!locked)
        {
            locked = true;
            audioSource.clip = radioNoise;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);

            audioSource.clip = songs[rand.Next(songs.Length)];
            int audioClipLength = (int)audioSource.clip.length;
            audioSource.time = rand.Next(audioClipLength / 15);
            audioSource.Play();
            locked = false;
        }

    }

}
