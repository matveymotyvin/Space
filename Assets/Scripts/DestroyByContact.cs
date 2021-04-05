using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Скрипт удаляет обьёкты при их соприкосновении и запускает реакцию взрыва, а также связанные с этим звуковые и анимационные эфекты

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;/*Получаем обьект взрыва обьекта, с которым произошло стокновение, настраиваем в Unity, 
    эфект взрыва создаём в Unity c помощью наложения разных систем частиц после чего из этого эфекта создаём префаб*/
    public GameObject explosionPlayer;/*Получаем игровой объект взрыва нашего игрока, настраиваем в Unity,
    эфект взрыва создаём в Unity c помощью наложения разных систем частиц после чего из этого эфекта создаём префаб*/
    private GameObject cloneExplosion;//Создаём клон эфекта взрыва для контрастности
    public int scoreValue;//переменная счётчик очков, настраиваем начальные данные в Unity
    private GameController gameController; // Переменная с тегом GameController для считывания игрового объекта
    private void Start()
    {
        //Проверяем наличие объекта с тегом GameController, при отсутствии выводим сообщение об ошибке
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if(GameControllerObject != null)
        {
            gameController = GameControllerObject.GetComponent<GameController>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("Скрипт 'GameController' не найден");
        }
    }
    private void OnTriggerEnter(Collider other)//Получаем координаты и позицию игровых объектов, в момент их столкновения
    {
        if (other.tag == "Player")//Проверяем какой это игровой объект
         //Если данные игровой объект Player
        {
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            /*Запускаем код который создаёт клон взрыва и запускает его в нужном
             месте на основе позиции игрока и на основе полученного префаба взрыва, а также угла под которым находтится объект Player */
            //вызов цикла для сообщения game Over
            //Вызываем завершение игры удаляем все игровые обьекты для очистки памяти
            gameController.GameOver();
            Destroy(other.gameObject);//Удаляем данные игровые обьекты при столкновении, не забыть включить тригер на обьекты
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
        if(other.tag == "Bolt")
        {//Если объект пуля
            cloneExplosion = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            /*Запускаем код который создаёт клон взрыва для пули и запускает его в нужном
             месте на основе позиции пули и на основе полученного префаба взрыва для пули, а также угла под которым находтится объект Bolt */
            //Удаляем все созданные и клонированные игровые обьекты для очистки памяти
            Destroy(other.gameObject);//Удаляем данные игровые обьекты при столкновении, не забыть включить тригер на обьекты
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
            //Вызываем функцию которая добавляет очки за уничтожение с помощью метода AddScore, кол-во очков которые добавляются за соответствующего убитового игрового объекта настраиваются в Unity
            gameController.AddScore(scoreValue);

        }
        
    }
}
