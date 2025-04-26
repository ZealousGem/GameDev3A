using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public Animator animator;
    private SpectatorState currentState;

    private float stateTimer;
    private float minTime = 2;
    private float maxTime = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();

        animator.SetFloat("Offset", Random.Range(0,1));

        SpectatorState randomState = GetRandomState();

        ChangeState(randomState);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState!=null)
        {
            //currentState.Update(this)
        }
        stateTimer -= Time.deltaTime;
        if (stateTimer <= 0)
        {
            ChangeState(GetRandomState());
        }



    }
    private void ChangeState(SpectatorState newState)
    {
        currentState = newState;
        currentState.Enter(this);
        stateTimer=Random.Range(minTime,maxTime);

    }
    private SpectatorState GetRandomState()
    {
        int random=Random.Range(0,3);

        switch(random)
        {
            case 0:return new AState();
            case 1:return new BState();
            case 2:return new CState();
                default: return null;
        }
        
    }
}
