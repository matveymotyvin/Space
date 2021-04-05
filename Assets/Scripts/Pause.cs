using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//скрипт, описывающий паузу
public class Pause : MonoBehaviour
{
    public string Scene; //название сцены, на которую будет происходить перемещение при паузе 
    private bool pause = false; //ставим флаг паузы
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //если нажата кнопка esc
        {
            if (!pause)
            {
                Time.timeScale = 0; //приостанавливаем игровое время
                pause = true; //ставим флаг
                SceneManager.LoadScene(Scene); //перемещаемся на сцену паузы

            }
            else //при повторном нажатии
            {
                Time.timeScale = 1; //восстанавливаем игровое время
                pause = false;
            }
        }
    }
}
