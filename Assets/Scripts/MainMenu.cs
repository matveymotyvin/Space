using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public bool isOpened = false;
    public bool isFullScreen = true;
    public AudioMixer audioMixer;
    public void ExitButton()
    {
        Application.Quit();
    }

    public void ChangeFullScreenMode(bool val)
    {
        isFullScreen = val;
    }

    public void ChangeVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", sliderValue);
    }

    public void ShowMainMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
    }

    public void SaveSettings()
    {
        Screen.fullScreen = isFullScreen;
    }
  
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            ShowMainMenu();
    }
}
