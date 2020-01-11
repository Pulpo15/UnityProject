using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject HealBulletPrefab;

    public Slider ChargingBar;
    public Slider CDBar;
    public Image SlowImage;
    public Image HealImage;

    bool shoot;
    bool isShooting;
    bool slowShoot;
    bool healShoot;
    bool joyShoot;

    float chargingValue;
    float temp;

    float time = 5f;
    public float curTime;

    void Start() {
        ChargingBar.gameObject.SetActive(false);
        slowShoot = true;
    }

    void Update() {
        //if (Input.GetKeyDown(KeyCode.Mouse0)) {
        //    GameObject Bullet;
        //    Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity,gameObject.transform);
        //    Bullet.SetActive(true);
        //}
        curTime -= Time.deltaTime;

        CDBar.value = curTime;

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetButtonDown("ChangeShoot") && curTime <= 0 && !slowShoot/* && !isShooting*/) {
            slowShoot = true;
            healShoot = false;
            curTime = time;
            ChargingBar.value = 0;
            chargingValue = 0;
            temp = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButtonDown("ChangeShoot") && curTime <= 0 && !healShoot/* && !isShooting*/) {
            slowShoot = false;
            healShoot = true;
            curTime = time;
            ChargingBar.value = 0;
            chargingValue = 0;
            temp = 0;
        }
        if (slowShoot)
            SlowShoot();
        if (healShoot)
            HealShoot();
    }

    void HealShoot() {
        SlowImage.color = Color.white;
        HealImage.color = Color.black;
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetAxis("Shoot") == 1 && temp <= 0) {

            GameObject Bullet;
            Bullet = Instantiate(HealBulletPrefab, transform.position, Quaternion.identity, gameObject.transform);
            Bullet.SetActive(true);

            isShooting = true;
            ChargingBar.gameObject.SetActive(true);

            shoot = true;
            ChargingBar.value = 1f;
            temp = ChargingBar.value;
        }

        if (shoot) {
            temp -= 0.005f;
            ChargingBar.value -= 0.005f;
        if (temp <= 0) {
                ChargingBar.gameObject.SetActive(false);
                shoot = false;
                isShooting = false;
            }
        }
    }



    void SlowShoot() {
        SlowImage.color = Color.black;
        HealImage.color = Color.white;
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetAxis("Shoot") > -1 && temp <= 0) {

            isShooting = true;
            joyShoot = true;
            ChargingBar.gameObject.SetActive(true);

            if (chargingValue <= 1f)
                    chargingValue += 0.005f;

            ChargingBar.value = chargingValue;

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) || Input.GetAxis("Shoot") == -1 && joyShoot && temp <= 0 && !shoot) {

            GameObject Bullet;
            Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity,gameObject.transform);
            Bullet.transform.localScale = new Vector3(Bullet.transform.localScale.x * chargingValue * 70, Bullet.transform.localScale.y * chargingValue * 70, Bullet.transform.localScale.z * chargingValue * 70);
            Bullet.SetActive(true);

            joyShoot = false;

            if (chargingValue <= 0.25f)
                chargingValue = 0.25f;

            shoot = true;
            temp = chargingValue;
        }

        if (shoot) {
            temp -= 0.005f;
            chargingValue -= 0.005f;
            ChargingBar.value = chargingValue;

            if (chargingValue <= 0) {
                ChargingBar.gameObject.SetActive(false);
                shoot = false;
                isShooting = false;
            }

        }
    }
}
