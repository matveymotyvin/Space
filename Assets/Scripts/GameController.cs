using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    private int score;
    public Text gameOverText;
    public Text restartText;
    private bool gameOver;
    private bool restart;

    public void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
        if (gameOver == true)
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
        score = 0;
        UpdateScore();
        StartCoroutine( SpawWaves());
    }
    IEnumerator SpawWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(Random.Range(0.5f, spawnWait));
            }
            
            yield return new WaitForSeconds(waveWait);
            
        }

    }
    void UpdateScore()
    {
        scoreText.text = "Счёт: " + score;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
