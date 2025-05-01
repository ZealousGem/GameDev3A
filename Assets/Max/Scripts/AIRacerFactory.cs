using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class AIRacerFactory : RacerFactory
{
    // Array of prefabs corresponding to ARacer, BRacer, and CRacer types.
    private GameObject[] prefabs;

    // Pool of suffixes used to make each racer's name unique and identifiable.
    private readonly string[] nameSuffixes =
    {
        "Alpha","Turbo","Viper", "Dash","Omega","Thunder"
    };

    //An array of GameObjects representing racer models
    public AIRacerFactory(GameObject[] prefabs)
    {
        this.prefabs = prefabs;
    }

    //Chooses which racer to create
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

        // Append a random suffix to the racer's name to ensure uniqueness
        string suffix = GetRandomSuffix();
        racer.RacerName += " " + suffix;
        return racer;
    }
    //A string suffix for unique naming
    private string GetRandomSuffix()
    {
        return nameSuffixes[UnityEngine.Random.Range(0, nameSuffixes.Length)];
    }

}
