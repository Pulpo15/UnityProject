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

    public void CreditsScene() {
        SceneManager.LoadScene(6);
    }

    public void Exit(){
        Application.Quit();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

}
