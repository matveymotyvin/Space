using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Скрипт отвечающий за движение корабля и его огонь
[System.Serializable]//Сериализуем наш новый класс, который делает класс доступный для изменения
public class Boundary {//Создаём публичный класс, специально для записи координат границы
    public float xMin, xMax, zMin, zMax;//Переменные координат границы игрового поля, настраиваем в инспекторе Unity
}
public class PlayerConroller : MonoBehaviour
{
	public static float Speed = 10;//Скорость корабля, меняется как в инспекторе Unity, так и в коде
	public float tilt;//Коэфициэнт для угла наклона, для симмуляции отклонения корабля при маневрировании 
	private Rigidbody m_rigidbody;
	public Boundary boundary;//Переменаая класса boundary настраиваем в инспекторе Unity

	public GameObject shot;//Обьект снаряда пули, модель и префаб которого мы создаём из систем чатиц в Unity, и после создаём из него префаб
	public Transform[] shotSpawns;//Переменная описывающая координаты снаряда 

	public static float fireRate = 0.5f; //Скорость выстрелов в данном случае 2 выстрела в секунду, настраиваентся как в инспекторе Unity, так и в скрипте
	public float nextFire = 0.0f;//Время через которое можно произвести следующий выстрел, настраиваентся как в инспекторе Unity, так и в скрипте
	//Огонь корабля
    public void Update()//Функция выполняется с каждым кадром
    {
		if (Input.GetButton("Fire1") && Time.time > nextFire)//Инициализируем выстрел только при нажатии кнопки огня и истечении времени следующего выстрела
        {
			nextFire = Time.time + fireRate;//Высчитываем время следующего выстрела
			foreach (var shotSpawn in shotSpawns) //Создаём клон пули при выстреле
			{
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);//Клонируем префаб пули в заданных координатах, координаты shotSpawn мы настраиваем в инспекторе Unity в носу корабля
			}
			GetComponent<AudioSource>().Play();//Проигрываем аудио сопроваждение выстрела, звуковую дорожку создаём и добавляем в Unity
		}
		
    }
    void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();// При старте игры получаем данные о компаненте Rigidbody игрока
	}
		private void FixedUpdate()//Вызывается каждый раз для разчёта физики обьекта и его перемещения
	{   //Получаем координаты корабля, а также получаем данные при нажатии кнопок управления на клавиатуре 
		float moveHorizontal = Input.GetAxis("Horizontal");//по горихонтальной оси
		float moveVertical = Input.GetAxis("Vertical");//по вертикальной оси
		//GetAxis возвращает значение с плавающей точной от -1 до 1

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);//осуществляем движения по заданным осям в зависимости от управления игроком
		m_rigidbody.velocity = movement * Speed;//движение зависит от параметра скорости, который мы можем менять как в инспекторе Unity, так и в скрипте
		//Создаём ограничение для перемещения корабля, чтобы он не выходил за границы игрового поля
		m_rigidbody.position = new Vector3
		(
			Mathf.Clamp(m_rigidbody.position.x, boundary.xMin, boundary.xMax),//Не позволяем игровому кораблю покидать границы поля
			0.0f,
			Mathf.Clamp(m_rigidbody.position.z, boundary.zMin, boundary.zMax)

		);

		m_rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, m_rigidbody.velocity.x * -tilt);//Создаём отклонение корабля при движении
		//Ставим -tilt, чтобы угол наклона был в разные стороны
		//Euler перемещает корабль относительно своей оси
	}


}