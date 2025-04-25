using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;




public class WayPointManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public List<WayPointNode> Waypoints; // list contain all the nodes
   
    public GameObject[] waypointPrefab; // contains all the gameobject points in the track
   

   

    
    public void addWaypoint() 
    {

        if (waypointPrefab == null || waypointPrefab.Length == 0)
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



        for (int i = 0; i < Waypoints.Count; i++)// links nodes together
        {
            Waypoints[i].nextNode = (i + 1 < Waypoints.Count) ? Waypoints[i+1] : Waypoints[0];
        }
       
    }

    private void Start()
    {
        //StartCoroutine(inDelay());
        addWaypoint();
    }

    IEnumerator inDelay()
    {
        yield return null;
        
    }

  

}
