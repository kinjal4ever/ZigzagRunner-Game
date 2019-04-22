using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    float size;
    Vector3 lastpos;
    void Start()
    {

        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
    }
}
