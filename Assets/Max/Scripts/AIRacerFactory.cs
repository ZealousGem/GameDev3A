using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerFactory : RacerFactory
{

    private GameObject[] prefabs;
    private readonly string[] nameSuffixes =
    {
        "Alpha","Turbo","Viper", "Dash","Omega","Thunder"
    };

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
        string suffix = GetRandomSuffix();
        racer.RacerName += " " + suffix;
        return racer;
    }
    private string GetRandomSuffix()
    {
        return nameSuffixes[UnityEngine.Random.Range(0, nameSuffixes.Length)];
    }

}
