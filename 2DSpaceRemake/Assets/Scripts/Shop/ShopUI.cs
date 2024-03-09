using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    public int choice;
    public GameObject[] spaceship;

    public void Start()
    {
        choice = PlayerPrefs.GetInt("choice");
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }
        spaceship[choice].SetActive(true);
    }

    public void Update()
    {
        choice = PlayerPrefs.GetInt("choice");

      foreach(GameObject go in spaceship)
        {
            go.SetActive(false);
        }

        spaceship[choice].SetActive(true);
        PlayerPrefs.SetInt("choice", choice);


        //switch (choice)
        //{
        //    case  0:
        //        spaceship[0].SetActive(true);
        //        spaceship[1].SetActive(false);
        //        spaceship[2].SetActive(false);
        //        spaceship[3].SetActive(false);
        //        break;
        //    case 1:
        //        spaceship[0].SetActive(false);
        //        spaceship[1].SetActive(true);
        //        spaceship[2].SetActive(false);
        //        spaceship[3].SetActive(false);
        //        break;
        //    case 2:
        //        spaceship[0].SetActive(false);
        //        spaceship[1].SetActive(false);
        //        spaceship[2].SetActive(true);
        //        spaceship[3].SetActive(false);
        //        break;
        //    case 4:
        //        spaceship[0].SetActive(false);
        //        spaceship[1].SetActive(false);
        //        spaceship[2].SetActive(false);
        //        spaceship[3].SetActive(true);
        //        break;
        //}
        
    }


}
