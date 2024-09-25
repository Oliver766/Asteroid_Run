using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController activePlayerController;

    public int choice;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            //For dbuging
            Debug.Log("Debuging or testing");
            GetFirstActiveController();
        }
        else
        {
            //IN A REAL GAME
            SetCurrentSpaceship();
        }
        choice = PlayerPrefs.GetInt("choice");



    }

    private void SetCurrentSpaceship()
    {
        int currentSpaceshipIdx = GameManager.instance.choice;

        int i = 0;
        foreach (Transform spaceship in this.transform)
        {
            int currentIdx = i;
            if (currentIdx == currentSpaceshipIdx)
            {
                //active it
                spaceship.gameObject.SetActive(true);
                activePlayerController = spaceship.GetComponent<PlayerController>();
            }
            else
            {
                //deactivate it
                spaceship.gameObject.SetActive(false);
            }
            i++;
        }

    }

    public void FireRockets()
    {
        activePlayerController.FireRockets();
    }

    private void GetFirstActiveController()
    {
        foreach (Transform spaceship in this.transform)
        {
            if (spaceship.gameObject.activeSelf == true)
            {
                activePlayerController = spaceship.GetComponent<PlayerController>();
                return;
            }
        }
    }
}
