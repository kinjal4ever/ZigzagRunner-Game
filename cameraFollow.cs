using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public GameObject ball;
    public bool gameOver;
    Vector3  offset;
    public float lerpRate;
    // Start is called before the first frame updatez
    void Start()
    {
        gameOver = false;
        offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
        {
            follow();
        }
    }

    void follow()
    {
        Vector3 pos = transform.position;
        Vector3 target = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, target, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
