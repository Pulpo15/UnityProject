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
    public EnemySpawner SpawnerEnemy;
    bool placeTurret;
    bool killEnemy;
    bool firstEnemy;
    bool placeNewTurret;
    bool remainingEnemies;
    bool newAmmo;
    bool newAmmoPressed;
    bool nextScene;
    float time = 1;
    public float curTime;
    int enemy = 0;
    bool catchedCoin;

    void Start() {
        TutorialText.text = "Acércate hacia la torreta y apunta hacia ella, Si tienes dinero suficiente pulsa Click derecho para comprarla";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !placeTurret) {
            TutorialText.text = "Mata enemigos para conseguir sus monedas y comprar mas torretas, si tu ataque colisiona con la torreta su velocidad de disparo se verá aumentada   (Pulsa espacio para continuar)";
            placeTurret = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoyX") && placeTurret == true && !killEnemy && !firstEnemy) {
            TutorialText.text = "Si un enemigo entra en el radio de acción de la torreta, esta le disparará hasta matarlo o ser destruida (Acuérdate de usar el Click izquierdo)";
            SpawnerEnemy.gameObject.SetActive(true);
            killEnemy = true;
            //GameObject Enemy = Instantiate(EnemyPrefab);
            //Enemy.SetActive(true);

        }
        if (killEnemy && !firstEnemy) {
            if (SpawnerEnemy.enemysPerRound == 4) {
                SpawnerEnemy.gameObject.SetActive(false);
                firstEnemy = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && placeNewTurret == true) {
            TutorialText.text = "Mata a los enemigos restantes";
            SpawnerEnemy.gameObject.SetActive(true);
            remainingEnemies = true;

        }
        if (remainingEnemies == true) {
            curTime -= Time.deltaTime;
            //if (curTime <= 0 && enemy <= 3) {
            //    InstantiateEnemies();
            //    enemy++;
            //}
        }
        intRemainingEnemies = int.Parse(RemainingEnemies.text);
        if (intRemainingEnemies <= 0 && !newAmmo) {
            TutorialText.text = "Pulsa 2 para cambiar el tipo de munición";
            newAmmo = true;
        }
        if (newAmmo && Input.GetKeyDown(KeyCode.Alpha2) && !newAmmoPressed) {
            TutorialText.text = "Esta nueva munición cura una pequeña porción de la vida de la torreta (Click izquierdo para usarla)";
            newAmmoPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && newAmmoPressed && !nextScene) {
            TutorialText.text = "Puedes cambiar entre la munición disponible pulsando 1 o 2(Pulsa espacio para continuar)";
            nextScene = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoyX") && nextScene) {
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
            TutorialText.text = "Ahora acércate a la otra torreta y compra una nueva";
            placeNewTurret = true;
            catchedCoin = true;
        }
    }
}
