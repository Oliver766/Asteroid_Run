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

    public GameObject mainmenu, shopmenu, map1;

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
                break;
            case MenuType.Map1Menu:
                map1.SetActive(true);
                shopmenu.SetActive(false);
                mainmenu.SetActive(false);
                break;
            case MenuType.ShopMenu:
                shopmenu.SetActive(true);
                map1.SetActive(false);
                mainmenu.SetActive(false);
                break;
        }

       
    }
  

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

  

    private void OnLevelSelect(int idx)
    {
        Debug.Log("We Press the level button " + idx);
        SceneManager.LoadScene("Level1");
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