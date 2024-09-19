using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int choice;
    public GameObject[] spaceship;

    public static GameManager instance;

   

    private void Awake()
    {
        if(instance == null)
        {

            instance = this;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
      
           



        choice = PlayerPrefs.GetInt("choice");
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }
        spaceship[choice].SetActive(true);



        DontDestroyOnLoad(gameObject);

    }

    public void Update(){

        choice = PlayerPrefs.GetInt("choice");
        PlayerPrefs.SetInt("choice", choice);

    }

 


  // public void Update()
   // {
           // num = PlayerPrefs.GetInt("num");
            //choice = PlayerPrefs.GetInt("choice");
            //PlayerPrefs.SetInt("choice", choice);
           // Debug.Log(choice);
            // foreach (GameObject go in spaceship)
           // {
            //go.SetActive(false);
            // }
        //spaceship[choice].SetActive(true);

    //}

}
