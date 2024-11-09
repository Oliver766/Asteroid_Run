using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public bool canseeThePlay;

    public override State RunCurrentState()
    {
        if(canseeThePlay)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
       
    }
}
