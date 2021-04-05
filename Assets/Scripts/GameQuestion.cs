using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//скрипт, создающий викторину
public class GameQuestion : MonoBehaviour
{
    public static float unscaledDeltaTime; //время между викторинами
    public QuestionsList[] questions; //массив вопросов викторин
    public Text questionText; //текстовые поля вопросов
    public Text[] answersText; //текстовые поля ответов
    public Button startButton; //кнопка начала викторин
    List<object> qList; //создаем лист для викторин
    QuestionsList crntQ;
    int randQ;

    public Button[] buttons; //массив кнопок
    public Color green;
    public Color red;
    public Color white;
    public Image[] images = new Image[3]; //изображение на кнопках
    public static float count1 = 0; //счетчик правильных ответов
    public static float count2 = 0; //счетчик не правильных ответов
    public void Play() //функция показа викторин
    {
        qList = new List<object>(questions); //берем вопросы из списка вопросов 
        QuestionGenerate();
        for (int i = 0; i < buttons.Length; i++) 
        {
            buttons[i].gameObject.SetActive(true); //прописываем ответы в кнопке ответов
        }
        startButton.gameObject.SetActive(false);
    }

    void QuestionGenerate() //функция генерации случайных вопросов (вопросы берутся случайным образом до тех пор, пока список вопросов не закончиться)
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionsList;
            questionText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
          StartCoroutine(Wait()); //задержка между ответом и появлением следующего вопроса
        }
        else
        {
            for (int i = 0; i < buttons.Length; i ++)
            {
                buttons[i].gameObject.SetActive(false);
            }
            questionText.text = "Вопросы закончились"; //вывод сообщения, когда все вопросы прорешаны 
            GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            
            startButton.gameObject.SetActive(true);
        }
        
    }

    IEnumerator Wait() //функция задержки между вопросами
    {
        yield return new WaitForSecondsRealtime (1f); //делаем задержку между вопросами независимой от общего игрового времени
    }

    IEnumerator TrueOrFalse(bool check, int index) //функция проверки правильности ответа
    {
        if (check) //если ответ правильный
        {
            images[index].color = green; //окрашиваем его в зеленый
            count1 = count1 + 1; //увеличиваем счетчик правильных ответов
            PlayerConroller.Speed = PlayerConroller.Speed*3/2; //увеличиваем скорость передвижения корабля
            PlayerConroller.fireRate = PlayerConroller.fireRate/2; //уменьшаем время между выстрелами
        }
        else //если ответ не правильный
        {
            count2 = count2 + 1; //увеличиваем счетчик неправильных ответов
            images[index].color = red; //окрашиваем в красный
            PlayerConroller.Speed = PlayerConroller.Speed * 2/3; //уменьшаем скорость передвижения
            PlayerConroller.fireRate = PlayerConroller.fireRate * 2; //увеличиваем время между выстрелами
        }
        yield return new WaitForSecondsRealtime(1f); //делаем задержку для следующей викторины не зависимо от общего игрового времени
        //yield return new WaitForSeconds(1f);
        images[index].color = white;
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }

    public void AnswersButtons(int index) //функция, прописывающая ответы в кнопке для ответов
    {
        if (answersText[index].text.ToString() == crntQ.answers[0])
        {
            StartCoroutine(TrueOrFalse(true, index));
        }
        else
        {
            StartCoroutine(TrueOrFalse(false, index));
        }
    }
    

}
[System.Serializable]
public class QuestionsList //класс, создающий список из вопросов и ответов
{
    public string question;
    public string[] answers = new string[3];
}
