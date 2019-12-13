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
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update() {

        if (Turret != null) {
            transform.LookAt(Turret.transform);
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
        else if (Turret == null) {
            transform.LookAt(Player.transform);
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(Turret);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Bullet") {
            Debug.Log("Enemy");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "PermanentTurret") {
            Debug.Log("EnemyTurretCollider");
            if (Turret == null)
                Turret = GameObject.Find("PermanentTurret(Clone)");
        }
    }
}
