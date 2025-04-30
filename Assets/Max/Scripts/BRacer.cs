using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BRacer : AIRacer
{
    public BRacer()
    {
        RacerName = "Muscle";
        Speed = 40;
        Brake = 10;
        //ModelPrefab = Resources.Load<GameObject>("Assets/Max/BRacerTest.prefab");

    }
    
}
