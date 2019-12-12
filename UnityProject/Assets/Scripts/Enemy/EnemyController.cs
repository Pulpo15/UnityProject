using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject Turret;

    void Start() {
        
    }
    
    void Update() {
        if (Turret == null)
            Turret = GameObject.Find("Turret(Clone)");
        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(Turret);
    }
}
