using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWaypointChecker : MonoBehaviour, PosCounter, Lapcount
{
    // Start is called before the first frame update

    WayPointNode curNode;
    Vector3 WayPoint;
    WayPointManager manager;

    public string Carname;

    [HideInInspector] // interface to be used to keep track of what position the player is in
    public int counter { get; set; }
    public float DistancefromWaypoint { get; set; }
    public string name { get; set; }
    public TMP_Text text { get; set; }

    public float WaypointBorder;

    public int Laps { get; set; }// a border used so the player doesnt have to reach the exact co-ords of the waypoint

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("UI").GetComponent<TMP_Text>();
        name = Carname;
        counter = 0;
        DistancefromWaypoint = 0f;
        Laps = 0;
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

    void SetWaypoint() // changes to next waypoint
    {
        if (curNode == null) return;
        Debug.Log("Waypoint reached");
        WayPoint = curNode.pos; // the next nodes location
       
    }

    public void DistFromCheckPoint() // calculates player distance from the waypoint
    {
        DistancefromWaypoint = Vector3.Distance(transform.position, WayPoint);
    }

  public void nextNode() // will change to next node once player has reached the previous waypoint
    {
        if (DistancefromWaypoint < WaypointBorder) // will only change to next node once player has reached the waypoint threshhold
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
