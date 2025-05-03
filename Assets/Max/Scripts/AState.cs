using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AState : SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        float offset = Random.Range(0f, 1f);
        //Debug.Log(offset);
        spectator.animator.Play("AAnimation", 0, offset);
        spectator.animator.SetInteger("State", 0);
    }
}
