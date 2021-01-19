using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroung : MonoBehaviour
{
    public float scrolSpeed;
    public float titleSize;
    private Transform currentObject;
    // Start is called before the first frame update
    void Start()
    {
        currentObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        currentObject.position = new Vector3(
            currentObject.position.x,
            currentObject.position.y,
            Mathf.Repeat(Time.time * scrolSpeed, titleSize));
    }
}
