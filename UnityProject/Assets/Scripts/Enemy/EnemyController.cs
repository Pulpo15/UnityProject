using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    GameObject Turret;
    GameObject Player;
    GameObject Nexus;
    NexusController NexusControllerCast;
    CharacterController Enemy;
    TurretHealthManager TurretHealthManagerCast;
    public float speed = 6f;
    public float damage;
    public float attackTime;
    float curAttackTime;

    public float gravity = 9.8f;
    public float fallVelocity = 0;

    //Vector3 move;

    void Start() {
        Enemy = GetComponent<CharacterController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Nexus = GameObject.FindGameObjectWithTag("Nexus");
        NexusControllerCast = Nexus.GetComponent<NexusController>();
        curAttackTime = attackTime;
        Physics.IgnoreCollision(Enemy.GetComponent<Collider>(), Player.GetComponent<Collider>());
    }
    
    void Update() {
        ObjectiveAssignement();
        curAttackTime -= Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "PermanentTurret") {
            if (Turret == null) {
                Turret = GameObject.Find("PermanentTurret(Clone)");
                TurretHealthManagerCast = Turret.GetComponent<TurretHealthManager>();
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "TurretWall") {
            if (curAttackTime <= 0 && Turret != null) {
                TurretHealthManagerCast.HealthUpdate(damage);
                curAttackTime = attackTime;
            }
        }
        //if (hit.gameObject.tag == "Nexus") {
        //    Debug.Log("NexusHit");
        //}
    }

    void ObjectiveAssignement() {
        if (Turret != null) {
            transform.LookAt(new Vector3 (Turret.transform.position.x, Turret.transform.position.y - 2.4f, Turret.transform.position.z));
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
        else if (Turret == null) {
            transform.LookAt(Nexus.transform);
            Enemy.Move(transform.forward * speed * Time.deltaTime);
        }
    }

    //void SetGravity() {
    //    if (Enemy.isGrounded) {
    //        fallVelocity = -gravity * Time.deltaTime;
    //        transform.forward = fallVelocity;
    //    }
    //    else {
    //        fallVelocity -= gravity * Time.deltaTime;
    //        move.y = fallVelocity;
    //    }
    //}
}
