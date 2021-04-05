using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт, контролирующий появление викторин в игре
public class Timer : MonoBehaviour
{
    public bool isOpened = true; //флаг появления викторины
    void Start()
    {
        StartCoroutine("DoMessage"); //вызываем корутину DoMessage
    }
    IEnumerator DoMessage() //бесконечный цикл с появлением викторин через заданное время
    {
        for (; ; )
        {
            ReplaceCamera();
            yield return new WaitForSecondsRealtime (10f); //делаем викторину независимой от общего игрового времени, чтобы она продолжала работать с промежутками в 10 секунд
        }
    }
    void ReplaceCamera() //функция, включения викторины
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
        if (isOpened == true) //при появлении викторины приостанавливаем общее игровое время
            Time.timeScale = 0;
        else //после, возобнавляем игровое время
            Time.timeScale = 1;
    }
}
