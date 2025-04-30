using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARacer : AIRacer
{
    public ARacer()
    {
        RacerName = "SedanRacer";
        Speed = 45;
        Brake = 15;

        Debug.Log("base speed of"+ RacerName + "is" + Speed);
        //ModelPrefab = Resources.Load<GameObject>("Assets/Max/ARacerTest.prefab");

    }
    
}
