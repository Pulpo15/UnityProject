using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    TurretController Turret;
    GameObject Enemy;
    public float speed;

    void Start() {
        Turret = GetComponentInParent<TurretController>();
        Enemy = Turret.Enemy;
    }

    void Update() {
        if (Enemy != null)
            transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position, speed);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
