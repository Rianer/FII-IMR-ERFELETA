using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float timeInSeconds;
    [SerializeField] int frames;
    double rotationAnglesClosedDoor = 180;
    double rotationAnglesOpenDoor = 100;
    double timeBetweenFrames;
    double doorRotationPerFrame;


    bool oppositeCoroutineActive = false;
    int currentFrame = 0;

    private void Start()
    {
        timeBetweenFrames = timeInSeconds / frames;
        doorRotationPerFrame = (rotationAnglesOpenDoor - rotationAnglesClosedDoor) / frames;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (oppositeCoroutineActive == false)
            {
                oppositeCoroutineActive = true;
            }
            else
            {
                StopAllCoroutines();
            }
            StartCoroutine(rotateDoor(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (oppositeCoroutineActive == false)
            {
                oppositeCoroutineActive = true;
            }
            else
            {
                StopAllCoroutines();
            }
            StartCoroutine(rotateDoor(false));
        }
    }


    IEnumerator rotateDoor(bool opens)
    {
        if (opens)
            currentFrame++;
        else
            currentFrame--;


        while (currentFrame >= 0 && currentFrame < frames)
        {
            Vector3 newDoorRotation;
            if (opens)
            {
                newDoorRotation = new Vector3(door.transform.localEulerAngles.x, door.transform.localEulerAngles.y, (float)(door.transform.localEulerAngles.z + doorRotationPerFrame));
            }
            else
            {
                newDoorRotation = new Vector3(door.transform.localEulerAngles.x, door.transform.localEulerAngles.y, (float)(door.transform.localEulerAngles.z - doorRotationPerFrame));
            }
            door.transform.localRotation = Quaternion.Euler(newDoorRotation);
            yield return new WaitForSeconds((float)timeBetweenFrames);

            if (opens)
                currentFrame++;
            else
                currentFrame--;

        }

/*        if (opens)
        {
            Debug.Log((float)rotationAnglesOpenDoor);
            door.transform.localRotation = Quaternion.Euler(new Vector3(door.transform.localEulerAngles.x, door.transform.localEulerAngles.y, 100));
            Debug.Log(door.transform.localRotation);
        }
        else
        {
            Debug.Log((float)rotationAnglesClosedDoor);
            door.transform.localRotation = Quaternion.Euler(new Vector3(door.transform.localEulerAngles.x, door.transform.localEulerAngles.y, 180));
            Debug.Log(door.transform.localRotation);
        }*/

        oppositeCoroutineActive = false;
    }

}
