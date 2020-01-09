using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexusController : MonoBehaviour {

    public Slider HPBar;
    public Text RemainingEnemies;
    public float HP;
    int layer = 0;
    int remainingEnemies;

    void Start() {
        //HPBar = GameObject.FindObjectOfType<Slider>();
    }

    void Update() {
        if (HP <= 0) {
            SceneManager.LoadScene(5);
        }
        remainingEnemies = int.Parse(RemainingEnemies.text);
        if (remainingEnemies <= 0) {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            layer++;
            if (layer > 1) {
                Destroy(other.gameObject);

                remainingEnemies = int.Parse(RemainingEnemies.text);
                remainingEnemies--;
                Debug.Log(remainingEnemies);
                RemainingEnemies.text = remainingEnemies.ToString();

                HP -= 0.2f;
                HPBar.value = HP;
                layer = 0;
            }
        }
    }
}
