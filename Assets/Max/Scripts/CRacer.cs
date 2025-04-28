using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRacer : AIRacer
{
    public CRacer()
    {
        RacerName = "CRacer";
        Speed = 50;
        Brake = 15;
        //ModelPrefab = Resources.Load<GameObject>("Assets/Max/CRacerTest.prefab");

    }
   
}
