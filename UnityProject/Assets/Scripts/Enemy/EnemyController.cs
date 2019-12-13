using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject Turret;
    GameObject Player;
    CharacterController Enemy;
    public float speed = 6f;

    void Start() {
        Enemy = GetComponent<CharacterController>();
    }
    
    void Update() {
        if (Turret == null)
            Turret = GameObject.Find("PermanentTurret(Clone)");

        if (Turret != null) {
            transform.LookAt(Turret.transform);
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(Turret);
    }
}
