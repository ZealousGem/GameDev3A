using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectator : MonoBehaviour
{
    public Animator animator;
    private SpectatorState currentState;

    private float stateTimer;
    private float minTime = 1;
    private float maxTime = 4;

    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();

        

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
        //Debug.Log("Changed to state: " + newState.GetType().Name);
        currentState.Enter(this);
        stateTimer=Random.Range(minTime,maxTime);
        //Debug.Log(stateTimer);
    }
    private SpectatorState GetRandomState()
    {

       

        while(true)
        {
            int random = Random.Range(0, 3);

            SpectatorState newState = random switch
            {
            0 => new AState(),
            1 => new BState(),
            2 => new CState(),
            _ => null
            };


            if (newState.GetType() != currentState?.GetType())
            {
                return newState;
            }

        } 

       


    }
}
