using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
   public State currentState;
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine(){

        State nextState = currentState?.RunCurrentState();

        if(nextState != null){

                //switch to the next state
                SwitchToNextState(nextState);
        }
    }
    private void SwitchToNextState(State nextState){

        currentState = nextState;


    }
}
