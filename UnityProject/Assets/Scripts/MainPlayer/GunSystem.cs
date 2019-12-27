using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour {

    public GameObject BulletPrefab;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            GameObject Bullet;
            Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity,gameObject.transform);
            Bullet.SetActive(true);
        }
    }
}
