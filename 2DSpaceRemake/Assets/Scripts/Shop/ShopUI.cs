using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject currentObj;
    public int choice;
    public GameObject[] spaceship;

    public void Start()
    {
        choice = PlayerPrefs.GetInt("choice");
    }

    public void Update()
    {
        if(choice == 1)
        {
            Debug.Log("Ship 1");
        }
    }


}
