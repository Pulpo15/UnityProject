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
        TutorialText.text = "Este es tu Núcleo, tienes que defenderlo de los enemigos, si lo alcanzan explotarán causando graves daños en el. Si el Núcleo se queda sin vida pierdes (Pulsa Espacio para continuar)";
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoyX") && !enemySpawned) {
            TutorialText.text = "Al llegar el enemigo al Núcleo lo destruirá";
            Enemy = Instantiate(EnemyPrefab);
            Enemy.SetActive(true);
            enemySpawned = true;
        }
        if (enemySpawned == true && Enemy == null) 
            TutorialText.text = "Prepárate, empezarás una nueva partida con todo lo aprendido.";
    }
}
