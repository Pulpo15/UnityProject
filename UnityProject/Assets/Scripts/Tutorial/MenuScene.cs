using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void NextScene() {
        SceneManager.LoadScene(1);
    }

}
