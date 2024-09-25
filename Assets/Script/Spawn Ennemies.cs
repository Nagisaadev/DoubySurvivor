using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectWave
{
    public List<GameObject> waveObject;
}

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObjectWave> waves = new List<GameObjectWave>();
 
    public int wave = 0;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Summon()
    {
        if (wave >= waves.Count) return;

        GameObjectWave currentWave = waves[wave];

        for (int i = 0; i < currentWave.waveObject.Count; i++)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = currentWave.waveObject[i];

            Instantiate(enemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
        wave += 1;
    }
}
