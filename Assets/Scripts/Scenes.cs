using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//скрипт, инициализирующий перемещение между сценами
public class Scenes : MonoBehaviour
{
    public void NextScene(int sceneNumber) //функция перемещения между сценами
    {
        SceneManager.LoadScene(sceneNumber); //осуществляем перемещение на следующую сцену
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
