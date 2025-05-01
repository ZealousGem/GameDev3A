using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIRacer 
{
    public string RacerName { get;  set; }
    public float Speed {  get; protected set; }
    public GameObject ModelPrefab { get;  set; }

    public float Brake { get; protected set; }
    

}
