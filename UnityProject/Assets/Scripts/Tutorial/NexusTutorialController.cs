using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexusTutorialController : MonoBehaviour
{
    public Slider HPBar;
    public Text RemainingEnemies;
    public float HP;
    int layer = 0;
    int remainingEnemies;
    Scene CurScene;

    float time = 5f;
    float curTime;

    void Start() {
        HPBar = GameObject.FindObjectOfType<Slider>();
        CurScene = SceneManager.GetActiveScene();
        curTime = time;
    }

    void Update() {
        if (HP <= 0) {
            MeshRenderer NexusMesh = gameObject.GetComponent<MeshRenderer>();
            NexusMesh.enabled = false;
            if (HPBar != null)
                Destroy(HPBar.gameObject);
            curTime -= Time.deltaTime;
            if (curTime <= 0)
                SceneManager.LoadScene(4);
        }
        remainingEnemies = int.Parse(RemainingEnemies.text);
        //if (remainingEnemies <= 0) {
        //    SceneManager.LoadScene(0);
        //}
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

                HP -= 1f;
                HPBar.value = HP;
                layer = 0;
            }
        }
    }
}
