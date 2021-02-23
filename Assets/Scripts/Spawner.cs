using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] float delay = 2f;
    [SerializeField] Transform[] spawners;
    private float nextSpawnTime;
    void Update()
    {
        if (CanSpawn())
        {
            Spawn();
        }
    }

    bool CanSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
    void Spawn()
    {
        nextSpawnTime = Time.time + delay;
        int randomNum = UnityEngine.Random.Range(0, spawners.Length);
        int randomNum2 = UnityEngine.Random.Range(0, enemies.Length);
        Instantiate(enemies[randomNum2], spawners[randomNum].transform.position, spawners[randomNum].transform.rotation);
    }
}
