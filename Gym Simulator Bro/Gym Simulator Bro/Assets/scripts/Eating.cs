using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : MonoBehaviour
{
    GameObject foodItem;
    AudioSource audioSource;
    [SerializeField]
    AudioClip eatingSound;
    bool locked = false;
    Coroutine eatingCoroutine;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Edible" && !locked)
        {
            locked = true;
            foodItem = other.gameObject;
            eatingCoroutine = StartCoroutine(eat());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == foodItem)
        {
            audioSource.Stop();
            StopCoroutine(eatingCoroutine);
            locked = false;
        }
    }

    IEnumerator eat()
    {
        audioSource.clip = eatingSound;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(foodItem);
        StatsController.Instance.IncreaseHunger(foodItem.GetComponent<EatableItems>().hunger);
        StatsController.Instance.IncreaseStamina(foodItem.GetComponent<EatableItems>().stamina);
        locked = false;
    }

}
