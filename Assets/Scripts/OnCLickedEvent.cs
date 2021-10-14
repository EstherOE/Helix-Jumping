using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnCLickedEvent : MonoBehaviour
{

    public Text soundText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
            soundText.text = "/";
        else
            soundText.text = "";

    }

   

    public void QuitGame()
    {
        Application.Quit();
    }

    public void  ToogleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            soundText.text = "";
        }

        else {
            GameManager.mute = true;
            soundText.text = " /";
                }
    }
}
