using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;




public class WayPointManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<WayPointNode> Waypoints;
    public GameObject[] waypointPrefab;
    int index;

   

    [ContextMenu("Add Waypoint")]
    public void addWaypoint()
    {

        if (waypointPrefab == null || waypointPrefab.Length == 0)
        {
            Debug.Log("not set");
            return;
        }
        for (int i = 0; i < waypointPrefab.Length; i++)
        {   
            GameObject obj = waypointPrefab[i];
            Vector3 postion = obj.transform.position;
            WayPointNode node = new WayPointNode(postion, obj);
            Waypoints.Add(node);
        }



        for (int i = 0; i < Waypoints.Count; i++)// links nodes
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

   /* void CreatePoint(WayPointNode point)
    {
        if(waypointPrefab != null)
        {
           //GameObject waypointOb = Instantiate(waypointPrefab, point.pos, Quaternion.identity, transform);
            

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
    } */

}
