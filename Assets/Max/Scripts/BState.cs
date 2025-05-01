using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BState : SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        float offset = Random.Range(0f, 1f);
        spectator.animator.Play("BAnimation", 0, offset);
        spectator.animator.SetInteger("State", 1);
    }
}
