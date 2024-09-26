using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerTime;
    public float waitTime;

    public float timer;
    public float subTimer = 0;
    
    public SpawnEnemies Summoner;
    private BornToDie DeathSentence;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerTime;
        subTimer = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (subTimer > 0) {
            subTimer -= Time.deltaTime;
            if (subTimer <= 0) {
                if (Summoner == null) {
                    Debug.Log($"Error i Want to avoid\n");
                } else {
                    Summoner.Summon();
                }
            }
        } else if (timer > 0) {
            timer -= Time.deltaTime;
            updateTimer(timer);
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

    void updateTimer (float currentTime) {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
