using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{   

    GameObject player;
    
    GameObject[] spawnPoints;


    private void Awake() {
        player = gameObject;

        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");

        int spawnPos = Random.Range(0,spawnPoints.Length);

        player.transform.position = spawnPoints[spawnPos].transform.position;
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
