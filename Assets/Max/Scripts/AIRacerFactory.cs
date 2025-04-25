using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacerFactory : RacerFactory
{

    public override AIRacer CreateRacer(int type)
    {

        switch(type)
        {
            case 0: return new ARacer();
            case 1: return new BRacer();
            case 2: return new CRacer();
            //default: return new AIRacer();
            default: throw new ArgumentException("Invalid racer type.");
        }
    }
    
}
