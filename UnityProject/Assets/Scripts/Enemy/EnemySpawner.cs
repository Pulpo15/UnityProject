using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float time;
    float curTime;
    public int enemysPerRound;
    public Text RemainingEnemysText;
    public GameObject Player;

    void Start() {
        curTime = time;
        RemainingEnemysText.text = enemysPerRound.ToString();
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
        Physics.IgnoreCollision(Enemy.GetComponent<Collider>(), Player.GetComponent<Collider>());
    }
}
