using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{

    public int money;

    public  static StatsController inst_controller;

    void Awake(){

        if(inst_controller == null)
        {

            inst_controller = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void Update(){

        if( money <= 0){
            money += 50;
        }
    }
 
}
