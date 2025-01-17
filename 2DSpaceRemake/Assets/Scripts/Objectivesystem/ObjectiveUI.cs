using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.IsolatedStorage;


public class ObjectiveUI : MonoBehaviour
{
   public levelScriptableObject lso;

   public bool completed;
   public bool unlocked;
   public Button button;
   public Color btncolor;
   public bool loadLevel;
   public GameObject warpObject;
   public Image transitionscreen;
 

   void Start(){
    completed = lso.LevelCompleted;
    unlocked = lso.LevelUnlocked;
    warpObject.SetActive(false);



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



    //SceneManager.LoadScene(lso.levelscene);
    StartCoroutine(loadingscene());

   }

   public IEnumerator loadingscene()
   {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(lso.levelscene);
        // don't let scene load yet
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone){

            // put animation here for scene  loading

            warpObject.SetActive(true);
            transitionscreen.gameObject.SetActive(true);

            asyncOperation.allowSceneActivation = true;

           // adding in warp particle effect
            // loading scene  syncronously
            // finish with a pat on  the back
        }
        yield return new WaitForSeconds(1f);


        
   }
}
