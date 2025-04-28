using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARacer : AIRacer
{
    public ARacer()
    {
        RacerName = "ARacer";
        Speed = 45;
        Brake = 10;

        Debug.Log("base speed of"+ RacerName + "is" + Speed);
        //ModelPrefab = Resources.Load<GameObject>("Assets/Max/ARacerTest.prefab");

    }
    
}
