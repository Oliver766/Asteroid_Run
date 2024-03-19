using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int choice;
    public GameObject[] spaceship;

    public static GameManager instance;

    public GameObject splashMENU;

    public int num;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }


        choice = PlayerPrefs.GetInt("choice");
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }
        spaceship[choice].SetActive(true);


        DontDestroyOnLoad(gameObject);

        num = PlayerPrefs.GetInt("num");

        if( num == 1)
        {
            splashMENU.SetActive(false);
        }

    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        PlayerPrefs.SetInt("num", 0);
    }

}
