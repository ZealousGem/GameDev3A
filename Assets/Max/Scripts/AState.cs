using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AState : SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        spectator.animator.SetInteger("State", 0);
    }
}
