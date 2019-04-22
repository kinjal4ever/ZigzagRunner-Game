using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb;

    public GameObject particle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButton(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.GameStart();
            }
        }
         
      if(!Physics.Raycast(transform.position,Vector3.down,1f))
        {
            gameOver = true;
            Camera.main.GetComponent<cameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if(Input.GetMouseButtonDown (0) && !gameOver)
        {
            SwitchDirections();
        }
    }

    void SwitchDirections()
    {
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Diamond")
        {
           GameObject part =  Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(part, 1f);
        }
    }
}
