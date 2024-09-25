using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerTime;
    public float waitTime;

    public float timer;
    public float subTimer = 0;
    
    public SpawnEnemy Summon;
    private BornToDie Kill;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerTime;
        subTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (subTimer > 0) {
            subTimer -= Time.deltaTime;
            if (subTimer <= 0) {
                Summon = GameObject.Find("Spawner").GetComponent<SpawnEnemy>();
            }
        } else if (timer <= 0) {
            timer = timerTime;
            subTimer = waitTime;
            Kill = GameObject.FindWithTag("Enemy").GetComponent<BornToDie>();
        } else if (timer > 0) {
            timer -= timer - Time.deltaTime;
        }

    }
}
