using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBulletSystem : MonoBehaviour
{
    public Rigidbody BulletRB;
    Vector3 Direction;
    TurretHealthManager Turret;
    public float velocity;
    public float time;
    float curTime;
    public int layer;


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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "TurretColliderForBullets") {
            Turret = other.gameObject.GetComponentInParent<TurretHealthManager>();
            Turret.curHealth += 0.15f;
            if (Turret.curHealth >= 1)
                    Turret.curHealth = 1;
            Destroy(gameObject);

        }
        //if (other.gameObject.tag == "PermanentTurret") {
        //    Turret = other.gameObject.GetComponent<TurretHealthManager>();
        //    if (layer > 0) {
        //        Turret.curHealth += 0.15f;
        //        if (Turret.curHealth >= 1)
        //            Turret.curHealth = 1;
        //        Destroy(gameObject);
        //    }
        //    layer++;
        //}
    }
}
