using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject zombiePrefab;
    int randomSpawnPoint;
    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnZombie", 0f, 3f);
    }

    void SpawnZombie()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiePrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
