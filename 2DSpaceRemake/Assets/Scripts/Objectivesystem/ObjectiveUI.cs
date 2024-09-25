using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectiveUI : MonoBehaviour
{
   public levelScriptableObject lso;

   public bool completed;
   public bool unlocked;

   public Button button;

   public Color btncolor;

 

   void Start(){
    completed = lso.LevelCompleted;
    unlocked = lso.LevelUnlocked;



    if(unlocked == false){
        button.interactable = false;
    }
   } 


   void Update(){
    if(completed == true){
        button.GetComponent<Image>().color = btncolor;
        button.interactable = false;

    }


   }

   public void levelload(){

    SceneManager.LoadScene(lso.levelscene);

   }
}
