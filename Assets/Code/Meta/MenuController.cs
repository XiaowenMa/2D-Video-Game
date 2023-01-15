using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    //outlets
    public GameObject mainMenu;
    public GameObject levelMenu;

    //methods
    void Awake()
    {
        instance = this;
        Hide();
    }

    void SwitchMenu(GameObject someMenu)
    {
        //Turn off all menus
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        //turn on requested menu
        someMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        SwitchMenu(mainMenu);
    }

    public void ShowLevelMenu()
    {
        SwitchMenu(levelMenu);
    }

    public void Show()
    {
        ShowMainMenu();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Scenes/Level_1");
    }
    //still need to write methods to load level 2 and 3... 
}
