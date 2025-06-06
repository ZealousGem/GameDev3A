using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Represents one of the spectator's animation states
public class AState : SpectatorState
{
    public override void Enter(Spectator spectator)
    {
        // Generate a random starting point in the animation
        float offset = Random.Range(0f, 1f);

        // Play the AAnimation from the random offset
        spectator.animator.Play("AAnimation", 0, offset);

        spectator.animator.SetInteger("State", 0);
    }
}
