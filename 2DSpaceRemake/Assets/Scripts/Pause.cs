using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Profiling;
// script by Oliver lancashire
// sid 1901981
public class Pause : MonoBehaviour
{
    [Header("Pause Bool")]
    public bool GameIsPaused;

    [Header("Game object references")]
    public GameObject pauseMenuUI;
    public int num;

    public static Pause instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }


    /// <summary>
    /// load scene
    /// </summary>
    /// <param name="index"></param>
    public void LoadLevel(int index)
    {
       
        SceneManager.LoadScene(index);
        num = 1;
        PlayerPrefs.SetInt("num", num);

    }

    
    public void Update()
    {
        // pause and un pause function
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause_();
            }
        }
    }

    /// <summary>
    /// runs function to play game and set everything back to true
    /// </summary>
    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.None;
        GameIsPaused = false;

    }

    /// <summary>
    /// pause entire game
    /// </summary>
    public void Pause_()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //Cursor.visible = true;
        GameIsPaused = true;
        //Cursor.lockState = CursorLockMode.None;

    }

    /// <summary>
    /// increases font size
    /// </summary>
    /// <param name="txt"></param>
    public void onClickEnter(TextMeshProUGUI txt)
    {
        txt.fontSize = 75;
    }
    // decreases font size
    public void onClickExit(TextMeshProUGUI txt)
    {
        txt.fontSize = 70;
    }



  
}

    