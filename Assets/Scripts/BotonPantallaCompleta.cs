using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPantallaCompleta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void fullscreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
        }

        else
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        Debug.Log("Fullscreen: " + Screen.fullScreen);
    }
}
