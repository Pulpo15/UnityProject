using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletSystem : MonoBehaviour
{
    public Rigidbody BulletRB;
    public float velocity;
    Vector3 Direction;
    public float time;
    float curTime;
    public int layer;
    //public float damage;

    EnemyController Enemy;
    TurretController Turret;

    void Start() {
        BulletRB = GetComponent<Rigidbody>();
        Direction = GameObject.Find("Main Camera").transform.forward * velocity;
        
        BulletRB.velocity = Direction;
        gameObject.transform.parent = null;
        curTime = time;
    }

    void Update() {

        curTime -= Time.deltaTime;

        if (curTime <= 0) {
            if (Enemy != null)
                Enemy.speed = 5;
            if (Turret != null)
                Turret.reloadTime = 0.3f;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            //EnemyHealthController HealthSystemCast = other.gameObject.GetComponent<EnemyHealthController>();
            //HealthSystemCast.HealthUpdate(damage);
            //Destroy(gameObject);
            if (layer > 2) {
                BulletRB.velocity = new Vector3(0, 0, 0);
                Enemy = other.gameObject.GetComponent<EnemyController>();
                Enemy.speed = 1;
            }
            layer++;
        }
        if (other.gameObject.tag == "PermanentTurret") {
            if (layer > 2) {
                BulletRB.velocity = new Vector3(0, 0, 0);
                Turret = other.gameObject.GetComponent<TurretController>();
                Turret.reloadTime = 0.15f;
            }
            layer++;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if (layer > 2) {
                EnemyController Enemy = other.gameObject.GetComponent<EnemyController>();
                Enemy.speed = 5;
            }
            layer++;
        }
    }
}
