using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    private GameObject cloneExplosion;
    public int scoreValue;
    private GameController gameController;
    private void Start()
    {
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cloneExplosion = Instantiate(explosionPlayer, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            //вызов цикла для сообщения game Over
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);
        }
        if(other.tag == "Bolt")
        {
            cloneExplosion = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation) as GameObject;
            Destroy(other.gameObject);
            Destroy(gameObject);
            Destroy(cloneExplosion, 1f);

            gameController.AddScore(scoreValue);
        }
        
    }
}
