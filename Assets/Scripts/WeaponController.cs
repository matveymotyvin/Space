using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт, управляющий огнем вражеского корабля
public class WeaponController : MonoBehaviour
{
    public GameObject shot; //переменная, содержащая ссылку на префаб выстрела вражеского корабля, который мы создаем в Unity
    public Transform shotSpawn; //переменная, содержащая ссылку на координаты выстрела (находится в носу вражеского корабля)
    public float fireRate; //частота, с которой будут вылетать пули
    public float delay; //задержка перед вызовом следующего огня
    private AudioSource audioS; //ссылка на аудиофайл звука выстрела вражеского корабля

    private void Start()
    {
        audioS = GetComponent<AudioSource>(); //получаем ссылку на аудиофайл
        InvokeRepeating("Fire", delay, fireRate); //функция, вызывающая функцию Fire с промежутками delay
    }

    private void Fire() //функция огня вражеского корабля
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //клонируем выстрел вражеского корабля в заданных координатах
        audioS.Play(); //проигрываем аудиофайл при выстреле
    }
}
