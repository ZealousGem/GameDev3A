using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RacingAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;

    public Transform WayPoint;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        agent.destination = WayPoint.position;
    }

    public void NextNode()
    {

    }
}
