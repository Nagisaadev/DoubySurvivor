using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerTime;
    public float waitTime;

    public float timer;
    public float subTimer = 0;
    
    public SpawnEnemy Summoner;
    private BornToDie DeathSentence;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerTime;
        subTimer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (subTimer > 0) {
            subTimer -= Time.deltaTime;
            if (subTimer <= 0) {
                Summoner.Summon();
            }
        } else if (timer > 0) {
            timer -= Time.deltaTime;
        } else if (timer <= 0) {
            timer = timerTime;
            subTimer = waitTime;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies) {
                DeathSentence = enemy.GetComponent<BornToDie>();
                if (DeathSentence != null) {
                    DeathSentence.TimeToDie();
                }
            }
        }
    }
}
