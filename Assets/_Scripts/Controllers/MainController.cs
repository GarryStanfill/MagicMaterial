using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public void ExitApplication()
    {
        Debug.Log("Quitting Application");
        Application.Quit();
    }

    public void Fullscreen()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

}
