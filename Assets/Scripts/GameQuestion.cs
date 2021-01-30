using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameQuestion : MonoBehaviour
{
    public QuestionsList[] questions;
    public Text questionText;
    public Text[] answersText;
    public Button startButton;
    List<object> qList;
    QuestionsList crntQ;
    int randQ;
    public Button[] buttons;
    public Color green;
    public Color red;
    public Color white;
    public Image[] images = new Image[3];
    public void Play()
    {
        qList = new List<object>(questions);
        QuestionGenerate();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        startButton.gameObject.SetActive(false);
    }

    void QuestionGenerate()
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
          //StartCoroutine(Wait());
        }
        else
        {
            for (int i = 0; i < buttons.Length; i ++)
            {
                buttons[i].gameObject.SetActive(false);
            }
            questionText.text = "Вопросы закончились";
            startButton.gameObject.SetActive(true);
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }

    IEnumerator TrueOrFalse(bool check, int index)
    {
        if (check)
        {
            images[index].color = green;
        }
        else
        {
            images[index].color = red;
        }
        yield return new WaitForSeconds(1f);
        images[index].color = white;
        qList.RemoveAt(randQ);
        QuestionGenerate();
    }

    public void AnswersButtons(int index)
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
public class QuestionsList 
{
    public string question;
    public string[] answers = new string[3];
}
