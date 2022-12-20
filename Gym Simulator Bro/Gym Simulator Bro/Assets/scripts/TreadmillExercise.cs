using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillExercise : MonoBehaviour
{
    bool rightHandInsideTreadmill = false;
    bool leftHandInsideTreadmill = false;
    double travelDistanceLeftHand;
    double travelDistanceRightHand;
    double exerciseStartTime;
    Vector3 oldPositionLeftHand;
    Vector3 oldPositionRightHand;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.EndsWith(" hand"))
            //Debug.Log("onTriggerEnter: " + other.name);
        if (other.name.Equals("right hand"))
            rightHandInsideTreadmill = true;
        else if (other.name.Equals("left hand"))
            leftHandInsideTreadmill = true;

        if (rightHandInsideTreadmill && leftHandInsideTreadmill)
        {
            exerciseStartTime = Time.time;

            if (other.name.StartsWith("left"))
                oldPositionLeftHand = other.transform.position;
            else
                oldPositionRightHand = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.EndsWith(" hand"))
            //Debug.Log("onTriggerExit: " + other.name);
        if (other.name.Equals("right hand"))
            rightHandInsideTreadmill = false;
        else if (other.name.Equals("left hand"))
            leftHandInsideTreadmill = false;


        if (exerciseStartTime != 0)
        {
            double elapsedTime = Time.time - exerciseStartTime;
            exerciseStartTime = 0;

            Debug.Log("Travel distance: " + (travelDistanceLeftHand + travelDistanceRightHand));
            Debug.Log("Elapsed Time: " + elapsedTime);
            double totalEffort = (travelDistanceLeftHand + travelDistanceRightHand) / elapsedTime;
            StatsController.Instance.IncreaseRespect((int)totalEffort);
            StatsController.Instance.DecreaseStamina((int)(totalEffort/2));


            travelDistanceLeftHand = 0;
            travelDistanceRightHand = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
/*        Debug.Log("onTriggerStay: " + other.name);*/
        if (other.name.EndsWith("hand") && rightHandInsideTreadmill && leftHandInsideTreadmill)
        {

            if (other.name.StartsWith("left"))
            {
                travelDistanceLeftHand += Vector3.Distance(other.transform.position, oldPositionLeftHand);
                oldPositionLeftHand = other.transform.position;
            }
            else
            {
                double distanceBetweenPositions = Vector3.Distance(other.transform.position, oldPositionRightHand);
                if (distanceBetweenPositions > 0)
                    Debug.Log("pos update: " + distanceBetweenPositions);
                travelDistanceRightHand += distanceBetweenPositions;
                oldPositionRightHand = other.transform.position;
            }


        }
    }
}
