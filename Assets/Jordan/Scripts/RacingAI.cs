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
        if (manager.Waypoints.Count() > 0) // will actvate the first node in the linkedlist
        {
            curNode = manager.Waypoints.NodeAcess(0); // sets waypointnode to the head node in the linkedlist 
            MoveCar(); // actviates movement for ai to head to waypointnodes position 
        }
    }

       
       

    // Update is called once per frame
    void Update()
    {
        agent.speed = Mathf.Lerp(agent.speed, curSpeed, Time.deltaTime * 2); // changes ai speed to desired current speed
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


        if (Waypoit.CompareTag("Checkpoint")) // will slow down if the waypoint has a checkpoint tag
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
                curNode = curNode.nextNode; // moves to nextNode

                if (curNode == manager.Waypoints.head) // checks if the linkedlist loop has reset 
                {
                    curNode = manager.Waypoints.head;
                }
                MoveCar();
               // Debug.Log(agent.speed);
            }
          
        }

        
       
    }
}
