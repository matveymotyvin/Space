using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//скрипт, описывающий главное меню, макет главного меню создается в Unity  и настраивается в инспекторе
public class MainMenu : MonoBehaviour
{
    public bool isOpened = false; //флаг открытия canvas
    public bool isFullScreen = true; //флаг открытия главного меню
    public AudioMixer audioMixer; //поле для настройки громкости
    public void ExitButton() //функция реализации кнопки выхода из игры
    {
        Application.Quit(); //выход из игры
    }

    public void ChangeFullScreenMode(bool val) //функция выбора режима 
    {
        isFullScreen = val; //открываем меню выбора режима, настраиваем в Unity
    }

    public void ChangeVolume(float sliderValue) //функция изменения громкости
    {
        audioMixer.SetFloat("MasterVolume", sliderValue);
    }

    public void ShowMainMenu() //функция показа главного меню
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened; // при открытии главного меню, закрываем canvas
    }

    public void SaveSettings() //функция сохранения настроек игры
    {
        Screen.fullScreen = isFullScreen;
    }
  
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //если нажата клавиша Esc, то 
            ShowMainMenu(); // показываем главное меню
    }
}
