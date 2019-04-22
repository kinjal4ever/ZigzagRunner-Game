using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner1 : MonoBehaviour
{
    public GameObject platform, diamond;
    public float size;
    Vector3 lastpos;
   public  bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        
        
      //  SpawnPlatform();

    }
    public void StartPlatformSpawning()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatform");
        }
    }
  

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if(rand <3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 3);
        if(rand <1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
       

    }

    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z+= size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rand = Random.Range(0, 3);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}
