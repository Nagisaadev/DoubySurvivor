using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public List<GameObject> wave;
}

[System.Serializable]
public class WaveList
{
    public List<Wave> waveList;
}

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;

    public WaveList waves = new WaveList();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Summon(int round)
    {
        for (int i = 0; i != waves[round].Length; i++) {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject Enemy = waves[round][i];

            Instantiate(Enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
    }
}
