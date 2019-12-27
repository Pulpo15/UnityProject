using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float time;
    float curTime;
    public int enemysPerRound;

    void Start() {
        curTime = time;    
    }

    void Update() {

        curTime -= Time.deltaTime;

        if (curTime <= 0 && enemysPerRound > 0) {
            SpawnEnemy();
            curTime = time;
            enemysPerRound--;
        }
    }

    void SpawnEnemy() {
        GameObject Enemy;
        Enemy = Instantiate(EnemyPrefab,transform.position,Quaternion.identity);
        Enemy.SetActive(true);
    }
}
