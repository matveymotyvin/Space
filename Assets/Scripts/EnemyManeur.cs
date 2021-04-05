using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт маневрирования вражеского корабля
public class EnemyManeur : MonoBehaviour
{
    public Vector2 startWait; //диапазон значений перемещения корабля 
    private float targetManeur; //максимальная дистанция смещения
    public float dodge; //максимальное значение маневра
    public Vector2 maneurTime; // максимальное время маневра
    public float maneurSpeed; //скорость маневра
    public Vector2 maneurWait; //максимальное время до следующего маневра
    private float currentSpeed; //текущая скорость
    public Boundary boundary; //координаты границ, за которыем не может вылетать вражеский корабль
    public float tilt; //угол наклона при маневрировании 
    private void Start()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade()); //вызов функции корутина
    }
    IEnumerator Evade() //функция с бесконечным циклом, вызывающая рандомное перемещение корабля
    {
        yield return new WaitForSeconds( //пауза перед первым маневрированием
            Random.Range(startWait.x,
            startWait.y
            )
            );

        while (true) //бесконечный цикл
        {
            targetManeur = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x); //дистанция смещения корабля

            yield return new WaitForSeconds( //пауза перед следующим маневрированием
                Random.Range(maneurTime.x,
            maneurTime.y
            ));

            targetManeur = 0;

            yield return new WaitForSeconds(
                Random.Range(maneurWait.x,
            maneurWait.y
            ));

        }

    }
    private void FixedUpdate() //функция, определяющая сам маневр
    {
        float newManeur = Mathf.MoveTowards( //создаем маневр на основе переданных параметров
        GetComponent<Rigidbody>().velocity.x,
        targetManeur, maneurSpeed * Time.deltaTime);

        GetComponent<Rigidbody>().velocity = new Vector3(newManeur, 0.0f, currentSpeed); //определяем направление движения с заданной скоростью

        GetComponent<Rigidbody>().position = new Vector3 //определяем координаты после перемещения
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax ), 0.0f, //контролируем выход корабля за границы
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax) 
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt); //вызываем поворот корабля при его маневрировании

    }
}
