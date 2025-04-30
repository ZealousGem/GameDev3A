using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypointChecker : MonoBehaviour, PosCounter
{
    // Start is called before the first frame update

    WayPointNode curNode;
    Vector3 WayPoint;
    WayPointManager manager;

    public string Carname;

    [HideInInspector]
    public int counter { get; set; }
    public float DistancefromWaypoint { get; set; }
    public string name { get; set; }

    public float WaypointBorder = 10f;

    void Start()
    {
        name = Carname;
        counter = 0;
        DistancefromWaypoint = 0f;
        manager = FindObjectOfType<WayPointManager>();
        if (manager.Waypoints.Count() > 0) // will actvate the first node in the linkedlist
        {
            curNode = manager.Waypoints.NodeAcess(0); // sets waypointnode to the head node in the linkedlist 
             // actviates movement for ai to head to waypointnodes position 
        }
    }

    // Update is called once per frame
    void Update()
    {
        DistFromCheckPoint();
        nextNode();
       
    }

    void SetWaypoint()
    {
        if (curNode == null) return;
        Debug.Log("Waypoint reached");
        WayPoint = curNode.pos; // the next nodes location
       
    }

    public void DistFromCheckPoint()
    {
        DistancefromWaypoint = Vector3.Distance(transform.position, WayPoint);
    }

  public void nextNode()
    {
        if (DistancefromWaypoint < WaypointBorder)
        {
            if (curNode != null)
            {
                counter++; // updates  the counter to determine what position the car is in
                curNode = curNode.nextNode;

                // moves to nextNode

                if (curNode == manager.Waypoints.head) // checks if the linkedlist loop has reset 
                {
                    curNode = manager.Waypoints.head;
                }
                SetWaypoint();
                // Debug.Log(agent.speed);
            }
        }
       
    }
}
