using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIRacer 
{
    public string RacerName { get; protected set; }
    public float Speed {  get; protected set; }
    public GameObject ModelPrefab { get;  set; }
    

}
