using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    //spawn variables
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    //side spawn variables
    private float spawnRangeZ = 15;
    private float spawnPosX = 25;
    //spawn timer variables
    private float startDelay = 2f;
    private float spawnInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //timer for animal spawning, set to 2, 1 by default(on this project)
        Invoke("SpawnRandomAnimal", startDelay);
    }

    void SpawnRandomAnimal()
    {
        int spawnSide = Random.Range(0, 3);
        //randomizes animal
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        if (spawnSide == 0)
        {
            //random x range on spawn
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            //spawns animal at generated pos
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }
        if (spawnSide == 1)
        {
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(5, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, -90, 0)));
        }
        if (spawnSide == 2)
        {
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(5, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        Invoke("SpawnRandomAnimal", spawnInterval);
    }
}
