using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool isOpened = true;
    void Start()
    {
        StartCoroutine("DoMessage");
    }
    IEnumerator DoMessage()
    {
        for (; ; )
        {
            ReplaceCamera();
            yield return new WaitForSeconds(20f);
        }
    }
    void ReplaceCamera()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
    }
}
