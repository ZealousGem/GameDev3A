using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;




public class WayPointManager : MonoBehaviour
{
    
    [HideInInspector]
    public CustomLinkedList Waypoints; // linkedlist that will contain the nodes of all the waypoints
    public GameObject[] waypointPrefab; // contains all the gameobject points in the track
   

   

    
    public void addWaypoint() 
    {

        if (waypointPrefab == null || waypointPrefab.Length == 0) // checks if waypoint objects are instantiated
        {
            Debug.Log("not set");
            return;
        }
        for (int i = 0; i < waypointPrefab.Length; i++) // will instiaite the node through a loop by grabbing the object and it's location
        {   
            GameObject obj = waypointPrefab[i];
            Vector3 postion = obj.transform.position;
            WayPointNode node = new WayPointNode(postion, obj);
            Waypoints.Add(node);
        }


        if (Waypoints.tail != null) // makes a circular list by making the tails nextNode equal the head instead of it becoming null to end the list 
        {
            Waypoints.tail.nextNode = Waypoints.head;
        }
       
    }

    private void Awake()
    {
        //StartCoroutine(inDelay());
        Waypoints = new CustomLinkedList(); // makes a new linked list once it's awake
        addWaypoint();
    }

}
