using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Скрипт управляющий движением пули ( лазерного луча-заранее созданный префаб)
public class Mover : MonoBehaviour
{
    public float speed;//Переменная скорости пули, настраивается как в скрипте, так и в инспекторе Unity
    public void Start()//Запускается в начале появления игрового объекта пули
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed;//Задаём направление движение вперёд на основе координат пули и скорости пули
    }
}
