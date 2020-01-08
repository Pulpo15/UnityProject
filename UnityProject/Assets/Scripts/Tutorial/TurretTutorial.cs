using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurretTutorial : MonoBehaviour {

    public Text TutorialText;
    public Text RemainingEnemies;
    public int intRemainingEnemies;
    public GameObject EnemyPrefab;
    bool placeTurret;
    bool killEnemy;
    bool placeNewTurret;
    bool remainingEnemies;
    float time = 1;
    public float curTime;
    int enemy = 0;
    bool catchedCoin;

    void Start() {
        TutorialText.text = "Approach to the Turret Socket and point towards it. If you have enough money Right Click it to place the Turret";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !placeTurret) {
            TutorialText.text = "Kill Enemies to get coins and buy some turrets (Press space to continue)";
            placeTurret = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && placeTurret == true && !killEnemy){
            TutorialText.text = "If an enemy enters to the Turret radius it will focus to try to kill it and the turret will shoot it (Remember to use Left Click)";
            GameObject Enemy = Instantiate(EnemyPrefab);
            Enemy.SetActive(true);
            killEnemy = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && placeNewTurret == true) {
            TutorialText.text = "Kill the remaining enemies";
            remainingEnemies = true;

        }
        if (remainingEnemies == true) {
            curTime -= Time.deltaTime;
            if (curTime <= 0 && enemy <= 3) {
                InstantiateEnemies();
                enemy++;
            }
        }
        intRemainingEnemies = int.Parse(RemainingEnemies.text);
        if (intRemainingEnemies <= 0) {
            SceneManager.LoadScene(3);
        }
    }

    void InstantiateEnemies() {
        GameObject Enemy = Instantiate(EnemyPrefab);
        Enemy.SetActive(true);
        curTime = time;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Coin" && !catchedCoin) {
            Debug.Log("asd");
            TutorialText.text = "Now approach to the other Turret Socket and buy the other turret";
            placeNewTurret = true;
            catchedCoin = true;
        }
    }
}
