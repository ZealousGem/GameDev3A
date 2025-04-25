using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerFactory : RacerFactory
{

    private GameObject[] prefabs;

    public AIRacerFactory(GameObject[] prefabs)
    {
        this.prefabs = prefabs;
    }

    public override AIRacer CreateRacer(int type)
    {
        AIRacer racer;
        switch (type)
        {
            case 0: racer = new ARacer(); break;
            case 1: racer = new BRacer(); break;
            case 2: racer = new CRacer(); break;
            default: throw new ArgumentException("Invalid racer type.");
        }
        racer.ModelPrefab = prefabs[type];
        return racer;
    }
    
}
