using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject Enemy;

    public float reloadTime = 0.5f;
    float curTime;

    void Start(){
        curTime = reloadTime;    
    }

    void Update() {
        curTime -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            if (Enemy == null) 
                Enemy = other.gameObject;
            if (Enemy != null) {
                    transform.LookAt(Enemy.transform);
                if (curTime <= 0) {
                    GameObject Bullet = Instantiate(BulletPrefab, transform.position + transform.forward * 1, transform.rotation, transform);
                    Bullet.SetActive(true);
                    curTime = reloadTime;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) {

    }
}
