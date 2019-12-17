using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject Turret;
    GameObject Player;
    CharacterController Enemy;
    TurretHealthManager TurretHealthManagerCast;
    public float speed = 6f;
    public float damage;
    public float attackTime;
    float curAttackTime;


    void Start() {
        Enemy = GetComponent<CharacterController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        curAttackTime = attackTime;
    }
    
    void Update() {
        ObjectiveAssignement();
        curAttackTime -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "PermanentTurret") {
            Debug.Log("EnemyTurretCollider");
            if (Turret == null) {
                Turret = GameObject.Find("PermanentTurret(Clone)");
                TurretHealthManagerCast = Turret.GetComponent<TurretHealthManager>();
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "PermanentTurret") {
            if (curAttackTime <= 0) {
                TurretHealthManagerCast.HealthUpdate(damage);
                curAttackTime = attackTime;
            }
        }
    }

    void ObjectiveAssignement() {
        if (Turret != null) {
            transform.LookAt(new Vector3 (Turret.transform.position.x, Turret.transform.position.y - 2.4f, Turret.transform.position.z));
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
        else if (Turret == null) {
            transform.LookAt(Player.transform);
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
    }
}
