using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float timerTime = 10f;
    public float timer = 0f;

    public bool hard = false;

    public GameObject[] enemies;

    public Transform[] spawnPoints;

//    public List rounds;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

            Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
            timer = timerTime;
        }
    }
}
