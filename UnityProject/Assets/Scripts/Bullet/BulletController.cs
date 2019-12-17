using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    TurretController Turret;
    EnemyHealthController HealthSystemCast;
    GameObject Enemy;
    public float speed;
    public float damage;
    int layer = 0;

    void Start() {
        Turret = GetComponentInParent<TurretController>();
        Enemy = Turret.Enemy;
        HealthSystemCast = Turret.Enemy.GetComponent<EnemyHealthController>();
    }

    void Update() {
        if (Enemy != null)
            transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, speed);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if (layer > 0) {
                Destroy(gameObject);
                HealthSystemCast.HealthUpdate(damage);
            }
            layer++;
        }
    }
}
