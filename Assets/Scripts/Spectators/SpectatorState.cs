using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.VersionControl.Asset;


//Abstract base class for spectator animation states.
public abstract class SpectatorState 
{
    public abstract void Enter(Spectator spectator);
   
}
