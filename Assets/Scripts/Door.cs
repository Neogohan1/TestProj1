using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Door : NetworkBehaviour
{
    public int minWaitTime;
    public int maxWaitTime;

    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        int startTime = Random.Range(minWaitTime,maxWaitTime);
        
        Invoke("OpenDoor", startTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OpenDoor(){
        
        GetComponent<BoxCollider2D>().enabled = !open;
        GetComponent<SpriteRenderer>().enabled = !open;
        open = !open;

        int startTime = Random.Range(minWaitTime,maxWaitTime);
        Invoke("OpenDoor", startTime);
        

    }
}
