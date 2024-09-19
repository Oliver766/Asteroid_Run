using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 50;
    public Vector3 rotationDirection;

     public int choice;
    public GameObject[] spaceship;
    void Update()
    {
        transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);

         choice = PlayerPrefs.GetInt("choice");
        PlayerPrefs.SetInt("choice", choice);
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }
        spaceship[choice].SetActive(true);
    }

    public void choicerfunc(){
       
        PlayerPrefs.SetInt("choice", choice);
        foreach (GameObject go in spaceship)
        {
            go.SetActive(false);
        }
        spaceship[choice].SetActive(true);
    }
}
