using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
//Клонирование игровых опасностей, а также контроль за положением игры (конец, рестарт)
public class GameController : MonoBehaviour
{
    public GameObject[] hazards; //переменная ссылка на префабы астероидов,  меняется как в инспекторе Unity, так и в коде
    public Vector3 spawnValues; //координаты волн,  меняется как в инспекторе Unity, так и в коде
    public int hazardCount; //количество астероидов в волне,  меняется как в инспекторе Unity, так и в коде
    public float spawnWait; //промежуток между астероидами,  меняется как в инспекторе Unity, так и в коде
    public float startWait; //время от начала игры до первой волны
    public float waveWait; //промежуток между волнами
    public Text scoreText; //текстовое поле для отображения счета
    public static int score; //переменная для подсчета счета
    public Text gameOverText; //текстовое поле для отображения конца игры
    public Text restartText; //текстовое поле для отображения перезагрузки
    private bool gameOver; //флаг конца игры
    private bool restart; //флаг перезагрузки

    public void Update()
    {
        if (restart) //если нажата restart, то заново перемещаемся на игровую сцену
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
        if (gameOver == true) //если конец игры, то выводим сообщение о restart
        {
            restartText.text = "Press 'R' to restart";
            restart = true;
        }

    }
    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0; //инициализируем счетчик очков
        UpdateScore(); //вызываем функцию увеличения очков
        StartCoroutine( SpawWaves()); //вызываем функцию генерации волн
    }
    IEnumerator SpawWaves() //функция создающая волны астероидов
    {
        yield return new WaitForSeconds(startWait); //задаем промежуток для первой волны
        while (!gameOver)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //определяем позицию новых астероидов
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Instantiate(hazard, spawnPosition, spawnRotation); //клонируем астероиды

                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait)); //задаем промежуток до следующей волны
            }
            
            yield return new WaitForSeconds(waveWait);
            
        }

    }
    void UpdateScore() //функция показа очков
    {
        scoreText.text = "Счёт: " + score;
    }
    public void AddScore(int newScoreValue) //функция подсчета очков
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver() //функция конца игры
    {
        SceneManager.LoadScene("EndScene"); //загружаем сцену конца игры
        gameOver = true; //ставим флаг true
    }
}
