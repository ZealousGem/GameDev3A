using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;



[System.Serializable]
public class WayPointNode
{
    public Vector3 pos;
    public WayPointNode nextNode;


    public WayPointNode(Vector3 pos)
    {
        this.pos = pos;
    }

}
public class WayPointManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<WayPointNode> Waypoints;
   public NavMeshAgent[] agent;
    public GameObject waypointPrefab;

    Vector3 mousePos;

    [ContextMenu("Add Waypoint")]
    public void addWaypoint()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        WayPointNode node = new WayPointNode(mousePos);
        
        Waypoints.Add(node);
       
      

        CreatePoint(node);
    }

    void CreatePoint(WayPointNode point)
    {
        if(waypointPrefab != null)
        {
           GameObject waypointOb = Instantiate(waypointPrefab, point.pos, Quaternion.identity, transform);
            

        }
    }

    public void UpdateWayPoint(int index, Vector3 pos)
    {
        if (index >= 0 && index < Waypoints.Count)
        {
            Waypoints[index].pos = pos;
        }

        else
        {
            Waypoints[1].pos = pos;
            index = 1;
        }
    }


    public void MoveWaypoint(int id, Vector3 newPos)
    {
        UpdateWayPoint(id, newPos);
    }

}
