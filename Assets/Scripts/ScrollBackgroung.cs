using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//функция прокрутки фона
//в Unity создаем фон, а также звезды из системы частиц
public class ScrollBackgroung : MonoBehaviour
{
    public float scrolSpeed; //скорость прокрутки фона
    public float titleSize; //высота фона
    private Transform currentObject; //переменная, содержащая ссылку на текущий объект (фон)
    // Start is called before the first frame update
    void Start()
    {
        currentObject = GetComponent<Transform>(); //получаем координаты объекта
    }

    // Update is called once per frame
    void Update()
    {
        currentObject.position = new Vector3( //осуществляем перемещение фона в соответствии со скоростью
            currentObject.position.x,
            currentObject.position.y,
            Mathf.Repeat(Time.time * scrolSpeed, titleSize)); //запускаем повторное перемещение, когда фон прокрутиться до конца
    }
}
