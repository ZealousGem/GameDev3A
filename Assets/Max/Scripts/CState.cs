using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CState :SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        float offset = Random.Range(0f, 1f);
        //Debug.Log($"CState: Playing 'CAnimation' with offset {offset:F2}");
        spectator.animator.Play("CAnimation", 0, offset);
        spectator.animator.SetInteger("State", 2);
    }
}
