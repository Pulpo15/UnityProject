using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour {

    public GameObject EnemyPrefab;
    GameObject Enemy;
    public Text TutorialText;
    bool movementText;
    bool shootText;
    bool enemyText;
    bool w, a, s, d = false;
    bool nextScene;

    float time = 10f;
    float curTime;

    void Start() {
        TutorialText.text = "Press W,A,S,D to move";
        curTime = time;
    }

    void Update() {


        if (!movementText) {
            if (Input.GetKeyDown(KeyCode.W))
                w = true;
            if (Input.GetKeyDown(KeyCode.A))
                a = true;
            if (Input.GetKeyDown(KeyCode.S))
                s = true;
            if (Input.GetKeyDown(KeyCode.D))
                d = true;
        }

        if (w == true && a == true && s == true && d == true && !shootText){
            TutorialText.text = "Pres right mouse to shoot";
            movementText = true;
            shootText = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && movementText == true && shootText == true && !enemyText) {
            TutorialText.text = "Shoot the enemy to kill him";
            Enemy = Instantiate(EnemyPrefab);
            Enemy.SetActive(true);
            enemyText = true;
        }
        if (Enemy == null && enemyText == true) {
            TutorialText.text = "Take the coin to earn money";
            nextScene = true;
        }
        if (nextScene == true) {
            curTime -= Time.deltaTime;
        }

        if (curTime <= 0) {
            Debug.Log("NextScene");
            SceneManager.LoadScene(2);
        }
    }
}
