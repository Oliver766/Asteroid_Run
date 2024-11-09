using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChaseState : State
{
    public AttackState attackState;
    public bool isInAttackingRange;
    public override State RunCurrentState()
    {
        if(isInAttackingRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
      
    }
  
}
