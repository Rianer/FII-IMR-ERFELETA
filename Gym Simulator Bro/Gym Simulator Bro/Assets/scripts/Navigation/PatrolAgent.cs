using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAgent : MonoBehaviour
{
   [SerializeField]
   private Transform[] points;
   [SerializeField]
   private float remainingDistance=0.5f;
   private int destinationPoint = 0;
   private UnityEngine.AI.NavMeshAgent agent;
   private void Start()
   {
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    agent.autoBraking = false;
    GoToNextPoint();
   }
   void GoToNextPoint()
   {
    if(points.Length==0){
        Debug.LogError("You must set destinations");
        enabled = false;
        return;
    }
    agent.destination=points[destinationPoint].position;
    destinationPoint = (destinationPoint+1)%points.Length;
   }

   private void Update()
   {
    if(!agent.pathPending && agent.remainingDistance<remainingDistance)
        {GoToNextPoint();}
   }
}