using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera playerCamera;
    [SerializeField] private BoxCollider shoulderLevelCollider;
    [SerializeField] private BoxCollider kneesLevelCollider;
    [SerializeField] List<float> heights; //first elemenent = center of shoulder level colider, 
                                          // second element = center of knee level colider,
                                          // third element = height of collider
                                          // fourth element = height of player body
    private Transform playerTransform;
    private Transform cameraTransform;

    private float globaShoulderColliderLimit;
    private float globalKneeColliderLimit;

    private bool objectLifted;
    void Start()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        cameraTransform = playerCamera.GetComponent<Transform>();
        globaShoulderColliderLimit = heights[3]/2 + heights[0] - heights[2];
        globalKneeColliderLimit = heights[3]/2 + heights[1] + heights[2];
        objectLifted = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform.position = new Vector3(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Liftable"))
        {
            Transform weightTransform = other.GetComponent<Transform>();
            GroundDistance distance = other.GetComponent<GroundDistance>();

            if (!objectLifted)
            {
                if (distance.distance >= globaShoulderColliderLimit)
                {
                    objectLifted = true;
                }
            }
            else
            {
                if(distance.distance <= globalKneeColliderLimit)
                {
                    objectLifted = false;
                    ApplyExerciseCompletion();
                }
            }
        }

    }


    private void ApplyExerciseCompletion()
    {
        StatsController.Instance.IncreaseRespect(2);
        StatsController.Instance.DecreaseStamina((int)(1));
        Debug.Log("Exercise is completed");
    }
}
