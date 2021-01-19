using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeur : MonoBehaviour
{
    public Vector2 startWait;
    private float targetManeur;
    public float dodge;
    public Vector2 maneurTime;
    public float maneurSpeed;
    public Vector2 maneurWait;
    private float currentSpeed;
    public Boundary boundary;
    public float tilt;
    private void Start()
    {
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
    }
    IEnumerator Evade()
    {
        yield return new WaitForSeconds(
            Random.Range(startWait.x,
            startWait.y
            )
            );

        while (true)
        {
            targetManeur = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(
                Random.Range(maneurTime.x,
            maneurTime.y
            ));

            targetManeur = 0;

            yield return new WaitForSeconds(
                Random.Range(maneurWait.x,
            maneurWait.y
            ));

        }

    }
    private void FixedUpdate()
    {
        float newManeur = Mathf.MoveTowards(
        GetComponent<Rigidbody>().velocity.x,
        targetManeur, maneurSpeed * Time.deltaTime);

        GetComponent<Rigidbody>().velocity = new Vector3(newManeur, 0.0f, currentSpeed);

        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax ), 0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);

    }
}
