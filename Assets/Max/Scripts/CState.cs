using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CState :SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        spectator.animator.SetInteger("State", 2);
    }
}
