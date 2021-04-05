//подключаем необходимые библиотеки
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//создаём класс EndScene
public class EndScene : MonoBehaviour

{
    //Создаём переменные
    public Text scoreText;//Подсчёт очков, текстовое поле расположение и размер настраиваем в Unity
    public Text qquestionText;//Подсёт кол-ва правильных ответов, текстовое поле расположение и размер настраиваем в Unity
    public Text gradeText;//Подсчёт оценки на основе кол-ва правильных ответов, текстовое поле расположение и размер настраиваем в Unity
    private static float count;//Дополнительная переменная счётчик, для сбора данных с разных классов, о кол-ве правильных ответов
    private int grade;//Переменная оценки
    public Button exitToMain;//Кнопка которая будет возвращать в главное меню, параметры, расположение и размеры настраиваются в Unity
    public string sceneNumber;//Переменная строка, которая в Unity настраивается и получает на вход название сцены, на которую будет перемещаться игра при нажатии кнопки
    // Start is called before the first frame update
    void Start()
    {
        //Собираем данные из других классов о кол-ве правильных ответов , кол-ве неправильных ответов, и считаем общее кол-во ответов которые дал студент  
        count = GameQuestion.count1 + GameQuestion.count2;
        //Собираем данные из других классов о кол-ве очков и выводим сообщение с количеством очков в задданное текстовое поле
        scoreText.text = "Ваш счёт равен : " + GameController.score;
        //Выводим сообщение с количеством правильных ответов и общим кол-вом ответов в задданное текстовое поле
        qquestionText.text = "Вы правильно ответили на " + GameQuestion.count1 +" из "+ count+" вопросов";
        //Высчитываем оценку студента в зависимости от кол-ва правильных ответов 
        if (GameQuestion.count1/count > 0.8)
            grade = 5;
        else if (GameQuestion.count1/count > 0.6)
            grade = 4;
        else if (GameQuestion.count1/count > 0.4)
            grade = 3;
        else
            grade = 2;
        //Выводим оценку студента в заранее созданное и настроенное соответствующее текстовое поле
        gradeText.text = "Ваша оценка : " + grade;
    }

    // Update is called once per frame
    void Update()
    {
        //При нажатии кнопки перемещаем игрока на сцену указанную в редакторе Unity
        if (exitToMain)
        {
            SceneManager.LoadScene(sceneNumber);
            /* Код метода Load Scene
            using UnityEngine;
            using UnityEngine.SceneManagement;

            public class LoadScene : MonoBehaviour
            {
                private AssetBundle myLoadedAssetBundle;
                private string[] scenePaths;

                // Use this for initialization
                void Start()
                {
                    myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
                    scenePaths = myLoadedAssetBundle.GetAllScenePaths();
                }

                void OnGUI()
                {
                    if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
                    {
                        Debug.Log("Scene2 loading: " + scenePaths[0]);
                        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
                    }
                }
            }
             */
        }
    }
}
