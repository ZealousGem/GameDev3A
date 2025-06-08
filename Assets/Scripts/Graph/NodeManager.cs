using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    // Start is called before the first frame update


    public  GameObject[] waypoints; // waypoints contained in the track
    public Links[] links; // waypoints that will have edges between each other
    public CustomGraph graph; // graph that will be used to calcualte the path

 

    void CreatePath() // instaties the waypoints and creates the edges 
    {
        if (waypoints.Length > 0)
        {
            for (int i = 0; i < waypoints.Length; i++) // adds waypoints into the point node list 
            {
                GameObject obj = waypoints[i];
                graph.AddNode(obj);
             
            }

            for (int i = 0; i < links.Length; i++) // adds the linked waypoints to create a edge path 
            {
                graph.AddEdges(links[i].firstnode, links[i].secondnode);
              /*  if (links[i].direction == Links.dir.BI)
                {
                    graph.AddEdges(links[i].secondnode, links[i].firstnode);
                   
                } */
            }
        }
    }

    void OnDrawGizmos() // a debug that shows the waypoints located in the track 
    {
        Gizmos.color = Color.green;
        foreach (GameObject wp in waypoints)
        {
            Gizmos.DrawSphere(wp.transform.position, 1f);
        }
    }

    private void Awake()
    {
       
        graph = new CustomGraph();
        CreatePath();
      
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L)) // debug to check pathing
        {
            graph.DrawEdges();
        }
       
    }
}
