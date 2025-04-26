using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RacingAI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    WayPointNode curNode;
    int index = 0;
    Vector3 WayPoint;
    WayPointManager manager;
    public float Topspeed;
    public  float BrakeSpeed;
    float curSpeed;
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        manager = FindObjectOfType<WayPointManager>();
        if (manager.Waypoints.Count > 0) // will actvate the first node in the list
        {
            curNode = manager.Waypoints[0];
            MoveCar();
        }
    }

       
       

    // Update is called once per frame
    void Update()
    {
        agent.speed = Mathf.Lerp(agent.speed, curSpeed, Time.deltaTime * 2);
        NextNode(); // will change the nodes to the next one
    //  Debug.Log(index);

    }

    public void MoveCar()
    {
        if (curNode == null) return;
       
            WayPoint = curNode.pos; // the next nodes location
            GameObject Waypoit = curNode.obj;
           // transform.LookAt(WayPoint);
          
        //Debug.Log(curNode.obj);
             agent.destination = WayPoint; // heads to the next location


        if (Waypoit.CompareTag("Checkpoint"))
        {

           

            curSpeed = BrakeSpeed;  // reduces speed by 10f

        }

        else
        {

            curSpeed = Topspeed; // increases speed by 10f

            


        }

        
       
    }

    public void NextNode()
    {
       // Debug.Log("NextNode() called");
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) // won't change to next node until the agent has reached the currentnodes co-ords
        {
            if (curNode != null)
            {
                curNode = curNode.nextNode;

                if (curNode == manager.Waypoints[manager.Waypoints.Count - 1])
                {
                    curNode = manager.Waypoints[0];
                }
                MoveCar();
                Debug.Log(agent.speed);
            }
          
        }

        
       
    }
}
