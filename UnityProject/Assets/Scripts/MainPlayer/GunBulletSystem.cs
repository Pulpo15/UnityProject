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
    public float damage;

    void Start() {
        BulletRB = GetComponent<Rigidbody>();
        Direction = GameObject.Find("Main Camera").transform.forward * velocity;
        
        BulletRB.velocity = Direction;
        gameObject.transform.parent = null;
        curTime = time;
    }

    void Update() {

        curTime -= Time.deltaTime;

        if (curTime <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            EnemyHealthController HealthSystemCast = other.gameObject.GetComponent<EnemyHealthController>();
            HealthSystemCast.HealthUpdate(damage);
            Destroy(gameObject);
        }
    }
}
