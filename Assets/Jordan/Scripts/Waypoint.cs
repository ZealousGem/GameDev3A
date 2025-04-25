using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WayPointNode
{
    public Vector3 pos;
    public GameObject obj;
    public WayPointNode nextNode;


    public WayPointNode(Vector3 pos, GameObject obj)
    {
        this.pos = pos;
        this.obj = obj;
        nextNode = null;
    }

}
public class Waypoint : MonoBehaviour
{
   
}
