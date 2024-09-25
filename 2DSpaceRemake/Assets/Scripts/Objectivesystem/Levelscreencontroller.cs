using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Levelscreencontroller : MonoBehaviour
{

    public levelScriptableObject[] lso;

    public int levelcompleted;
   


    // Start is called before the first frame update
    void Start()
    {
        levelcompleted = PlayerPrefs.GetInt("levelcounter");
    }

    // Update is called once per frame
    void Update()
    {
        if(levelcompleted == 1){
            lso[1].LevelUnlocked = true;
        }
         else if(levelcompleted == 2){
            lso[2].LevelUnlocked = true;
        }
        else if(levelcompleted == 3){
            lso[3].LevelUnlocked = true;
        }
        else if(levelcompleted == 4){
            lso[4].LevelUnlocked = true;
        }
       else if(levelcompleted == 5){
            lso[5].LevelUnlocked = true;
        }

    }
}
