using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexusTutorial : MonoBehaviour {

    public Text TutorialText;
    public GameObject EnemyPrefab;
    GameObject Enemy;

    bool enemySpawned;

    void Start() {
        TutorialText.text = "This is your Nexus, you have to defend it from the enemies, if they get to it they will explode by damaging it. If the Nexus runs out of life you will lose.(Press Space to continue)";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !enemySpawned) {
            TutorialText.text = "Kill the enemy to prevent the damage to the Nexus";
            Enemy = Instantiate(EnemyPrefab);
            Enemy.SetActive(true);
            enemySpawned = true;
        }
        if (enemySpawned == true && Enemy == null) 
            TutorialText.text = "Get ready, you will start a new game";
    }
}
