using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour {

    public GameObject EnemyPrefab;
    public EnemySpawner SpawnerEnemy;
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
        TutorialText.text = "Pulsa W, A, S y D para moverte";
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
            TutorialText.text = "Manten pulsado el Click izquierdo para cargar tu ataque. Dependiendo de la carga la esfera será más grande pero tardará más en estar disponible de nuevo";
            movementText = true;
            shootText = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && movementText == true && shootText == true && !enemyText) {
            TutorialText.text = "Tus balas no afectan a la vida del enemigo, en este caso solo realentizas su paso ¡Cuidado!, Si la esfera interior no colisiona con el enemigo esta no se parará (Pulsa Espacio cuando estés listo)";
            SpawnerEnemy.gameObject.SetActive(true);
            //Enemy = Instantiate(EnemyPrefab);
            //Enemy.SetActive(true);
            enemyText = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("JoyX") && enemyText == true) {
            SceneManager.LoadScene(2);
        }
    }
}
