using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabToSpawn;
    private Vector3 spawnPosition = new Vector3(25,0,0);
    public float spawnDelay;
    public float spawnRate;
    public PlayerController _PlayerController;
    public GameObject[] obstaclePrefabs;
    private int randomObstacle;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRate);
    }

    // Update is called once per frame
    /*void SpawnPrefab()
    {
        spawnRate= Random.Range(1.2f,4f);
        if(_PlayerController.gameHasEnded == false)
        {
            Instantiate(prefabToSpawn,spawnPosition,prefabToSpawn.transform.rotation);
        }
        
    }*/
    void SpawnObstacle ()
    {
        if(_PlayerController.gameHasEnded == false)
        {
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomObstacle], spawnPosition, obstaclePrefabs[randomObstacle].transform.rotation);
            
        }
            
    }

}
