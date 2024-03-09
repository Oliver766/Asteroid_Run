using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public Transform levelContainer;
    public RectTransform menuContainer;

    private int screenWidth;

    public Transform shopButtonParent;

    public GameObject mainmenu, shopmenu, map1, spaceships;

    public MenuType menutype;


    private void Start()
    {
        screenWidth = Screen.width;

    }

    private void Update()
    {
        switch (menutype)
        {
            case MenuType.MainMenu:
                mainmenu.SetActive(true);
                map1.SetActive(false);
                shopmenu.SetActive(false);
                spaceships.SetActive(true);

                break;
            case MenuType.Map1Menu:
                map1.SetActive(true);
                shopmenu.SetActive(false);
                mainmenu.SetActive(false);
                spaceships.SetActive(false);
   
                break;
            case MenuType.ShopMenu:
                shopmenu.SetActive(true);
                map1.SetActive(false);
                mainmenu.SetActive(false);
                spaceships.SetActive(true);

                break;
        }

       
    }
  

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

  

    public void OnLevelSelect(int idx)
    {
        Debug.Log("We Press the level button " + idx);
        SceneManager.LoadScene(idx);
    }

    public void OnPlayButtonClicked()
    {
        Debug.Log("Play Button Clicked");
        menutype = MenuType.Map1Menu;
    }

    public void OnMainMenuButtonClicked()
    {
        Debug.Log("Clicked main button");
        menutype = MenuType.MainMenu;
    }

    public void OnShopButtonClicked()
    {
        Debug.Log("Clicked shop button");
        menutype = MenuType.ShopMenu;
    }

    public void OnNextMapButtonClicked()
    {
        Debug.Log("Next map clicked");
    }

    public enum MenuType
    {
        MainMenu,
        Map1Menu,
        ShopMenu
    }

}