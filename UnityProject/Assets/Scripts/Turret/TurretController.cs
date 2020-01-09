using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject Enemy;
    Rigidbody SlowBullet;
    Rigidbody HealBullet;
    bool layerToZero;

    public float reloadTime = 0.5f;
    float curTime;

    int layer;
    int healLayer;

    void Start(){
        curTime = reloadTime;    
    }

    void Update() {
        curTime -= Time.deltaTime;
        if (SlowBullet != null && SlowBullet.velocity == new Vector3(0,0,0)) {
            layer = 0;
            layerToZero = false;
        }

        if (HealBullet == null)
            healLayer = 0;
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

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "SlowBullet"){
            SlowBullet = collision.gameObject.GetComponentInParent<Rigidbody>();
            layer++;
            if (layer == 2) {
                SlowBullet.velocity = new Vector3(0, 0, 0);
                layerToZero = true;
            }
        }
        if (collision.gameObject.tag == "HealBullet") {
            HealBullet = collision.gameObject.GetComponent<Rigidbody>();
            healLayer++;
            if (healLayer == 2) {
                gameObject.GetComponent<TurretHealthManager>().curHealth += 15f;
                if (gameObject.GetComponent<TurretHealthManager>().curHealth >= 1)
                    gameObject.GetComponent<TurretHealthManager>().curHealth = 1;
                Destroy(collision.gameObject);
            }

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "SlowBullet")
            layer = 0;
    }
}
