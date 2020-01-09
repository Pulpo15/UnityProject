using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletSystem : MonoBehaviour
{
    public Rigidbody BulletRB;
    public GameObject Player;
    public EnemySpawner EnemyNumber;
    public GameObject EnemyCollision;
    int TotalRoundEnemies;
    public float velocity;
    Vector3 Direction;
    public float time;
    float curTime;
    public int layer;
    int newLayer;
    public int turretLayer;
    public int curEnemy;
    //public float damage;

    public EnemyController[] Enemy;
    TurretController Turret;

    void Start() {
        BulletRB = GetComponent<Rigidbody>();
        Direction = GameObject.Find("Main Camera").transform.forward * velocity;

        TotalRoundEnemies = EnemyNumber.publicEnemiesPerRound;
        Enemy = new EnemyController[TotalRoundEnemies];
        BulletRB.velocity = Direction;
        gameObject.transform.parent = null;
        curTime = time;
    }

    void Update() {

        curTime -= Time.deltaTime;

        if (curTime <= 0) {
            for (int i = 0; i < Enemy.Length; i++) { 
                if (Enemy[i] != null) {
                    Enemy[i].speed = 5;
                    Enemy[i].canBeTakenByGun = true;
                }
            }
            if (Turret != null)
                Turret.reloadTime = 0.3f;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Enemy" && EnemyCollision == null) {
            EnemyCollision = other.gameObject;
            //EnemyHealthController HealthSystemCast = other.gameObject.GetComponent<EnemyHealthController>();
            //HealthSystemCast.HealthUpdate(damage);
            //Destroy(gameObject);
        }
        if (other.gameObject == EnemyCollision) {
            if (layer > 2) {
                BulletRB.velocity = new Vector3(0, 0, 0);
            }
            layer++;
        }
        if (other.gameObject.tag == "Enemy" && EnemyCollision != null) {
            if (other.gameObject.GetComponent<EnemyController>().canBeTakenByGun) {
                Enemy[curEnemy] = other.gameObject.GetComponent<EnemyController>();
                Enemy[curEnemy].canBeTakenByGun = false;
            }
            if (curEnemy < TotalRoundEnemies && Enemy[curEnemy] != null) {
                Enemy[curEnemy].speed = 1;
                curEnemy++;
            }
            newLayer++;
        }

        if (other.gameObject.tag == "PermanentTurret") {
            if (turretLayer > 1) {
                Turret = other.gameObject.GetComponent<TurretController>();
                Turret.reloadTime = 0.15f;
            }
            //if (turretLayer > 2) {
            //    BulletRB.velocity = new Vector3(0, 0, 0);
            //}
            turretLayer++;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemy") 
            other.gameObject.GetComponent<EnemyController>().speed = 1;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if (layer > 2) {
                EnemyController Enemy = other.gameObject.GetComponent<EnemyController>();
                Enemy.speed = 5;
            }
            layer++;
        }
        if (other.gameObject.tag == "PermanentTurret") {
            if (turretLayer > 2 && Turret != null) {
                Turret.reloadTime = 0.3f;
            }
            turretLayer++;
        }
    }
}
