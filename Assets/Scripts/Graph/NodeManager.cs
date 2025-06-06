using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    // Start is called before the first frame update


    public  GameObject[] waypoints;
    public Links[] links; 
    public CustomGraph graph;

    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePath()
    {
        if (waypoints.Length > 0)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                GameObject obj = waypoints[i];
                graph.AddNode(obj);
              //  Debug.Log("Node Added: " + obj.name);
            }

            for (int i = 0; i < links.Length; i++)
            {
                graph.AddEdges(links[i].firstnode, links[i].secondnode);
              /*  if (links[i].direction == Links.dir.BI)
                {
                    graph.AddEdges(links[i].secondnode, links[i].firstnode);
                   
                } */
            }
        }
    }

    void OnDrawGizmos()
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
}
