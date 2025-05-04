using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WayPointNode
{
    public Vector3 pos; // contains the position of the node
    public GameObject obj; // contains the waypoint ojbcet
    public WayPointNode nextNode; // a null node that will be instated from the previous node in the list


    public WayPointNode(Vector3 pos, GameObject obj) // contructor that will be called to instatie attributes in the node
    {
        this.pos = pos;
        this.obj = obj;
        nextNode = null; // sets the next node to null so it can be transition easily 
    }

}
public class Waypoint : MonoBehaviour
{
   
}
