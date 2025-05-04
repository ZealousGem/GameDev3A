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

            // Get the type of the newly selected random state.
            System.Type newStatType = newState.GetType();
            System.Type currentStateType;


           
            if(currentState!=null)
            {
                // If currentState exists, get its type.
                currentStateType = currentState.GetType();
            }
            else
            {
                currentStateType = null;
            }
            //we compare the two types
            bool isSameType =(newStatType == currentStateType);

            if (isSameType ==false)
            {
                return newState;
            }

        } 

    }
}
