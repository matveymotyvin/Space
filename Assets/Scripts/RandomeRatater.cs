using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Скрипт осуществляющий хаотичное вращение астероидов
public class RandomeRatater : MonoBehaviour
{
    public float tumble;//Скорость вращения астероидов, задаём в инспекторе Unity
    private Rigidbody rb;//Переменная для доступа к компаненту Rigidbody текущего объекта
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Получаем компаненты Rigidbody текущего обьекта
        rb.angularVelocity = new Vector3(1, 1, 1) * tumble;//Задаём новое положение оси астеройда, для его вращения
        //Примечание надо отключить свойство АngularDrag в свойствах Rigidbody для того чтобы вращение астероидов не затухало
        rb.angularVelocity = Random.insideUnitSphere * tumble;//Делаем вращение астероида рандомным 
        
    }

}
