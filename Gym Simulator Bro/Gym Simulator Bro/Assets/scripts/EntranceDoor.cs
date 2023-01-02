using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour
{
    [SerializeField] GameObject leftDoor;
    [SerializeField] double xOpenPositionLeftDoor;
    [SerializeField] double xClosedPositionLeftDoor;
    [SerializeField] GameObject rightDoor;
    [SerializeField] double xOpenPositionRightDoor;
    [SerializeField] double xClosedPositionRightDoor;
    [SerializeField] float timeInSeconds;
    [SerializeField] int frames;
    Coroutine openDoors;
    Coroutine closeDoors;
    double timeBetweenFrames;
    double leftDoorTravelDistancePerFrame;
    double rightDoorTravelDistancePerFrame;


    bool oppositeCoroutineActive = false;
    int currentFrame = 0;

    private void Start()
    {
        timeBetweenFrames = timeInSeconds / frames;
        leftDoorTravelDistancePerFrame = (xOpenPositionLeftDoor - xClosedPositionLeftDoor) / frames;
        rightDoorTravelDistancePerFrame = (xOpenPositionRightDoor - xClosedPositionRightDoor) / frames;
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
            openDoors = StartCoroutine(slide(true));
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
            closeDoors = StartCoroutine(slide(false));
        }
    }


    IEnumerator slide(bool opens)
    {
        if (opens)
            currentFrame++;
        else
            currentFrame--;


        while(currentFrame >=0 && currentFrame < frames)
        {
            Vector3 newLeftDoorPosition;
            Vector3 newRightDoorPosition;
            if (opens)
            {
                newLeftDoorPosition = new Vector3((float)(leftDoor.transform.localPosition.x + leftDoorTravelDistancePerFrame), leftDoor.transform.localPosition.y, leftDoor.transform.localPosition.z);
                newRightDoorPosition = new Vector3((float)(rightDoor.transform.localPosition.x + rightDoorTravelDistancePerFrame), rightDoor.transform.localPosition.y, rightDoor.transform.localPosition.z);

            }
            else
            {
                newLeftDoorPosition = new Vector3((float)(leftDoor.transform.localPosition.x - leftDoorTravelDistancePerFrame), leftDoor.transform.localPosition.y, leftDoor.transform.localPosition.z);
                newRightDoorPosition = new Vector3((float)(rightDoor.transform.localPosition.x - rightDoorTravelDistancePerFrame), rightDoor.transform.localPosition.y, rightDoor.transform.localPosition.z);
            }
            leftDoor.transform.localPosition = newLeftDoorPosition;
            rightDoor.transform.localPosition = newRightDoorPosition;
            yield return new WaitForSeconds((float)timeBetweenFrames);

            if (opens)
                currentFrame++;
            else
                currentFrame--;

        }

        if (opens)
        {
            leftDoor.transform.localPosition = new Vector3((float)xOpenPositionLeftDoor, leftDoor.transform.localPosition.y, leftDoor.transform.localPosition.z);
            rightDoor.transform.localPosition = new Vector3((float)xOpenPositionRightDoor, rightDoor.transform.localPosition.y, rightDoor.transform.localPosition.z);
        }
        else
        {
            leftDoor.transform.localPosition = new Vector3((float)xClosedPositionLeftDoor, leftDoor.transform.localPosition.y, leftDoor.transform.localPosition.z);
            rightDoor.transform.localPosition = new Vector3((float)xClosedPositionRightDoor, rightDoor.transform.localPosition.y, rightDoor.transform.localPosition.z);

        }

        oppositeCoroutineActive = false;
    }

}
