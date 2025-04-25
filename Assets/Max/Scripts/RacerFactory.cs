using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RacerFactory 
{

    public abstract AIRacer CreateRacer(int type);
}
