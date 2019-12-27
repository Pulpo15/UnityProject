using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletSystem : MonoBehaviour
{
    public Rigidbody BulletRB;
    public float velocity;
    Vector3 Direction;


    private void Awake() {
    }

    void Start() {
        BulletRB = GetComponent<Rigidbody>();
        Direction = transform.forward;
        transform.rotation = transform.parent.rotation;
        BulletRB.velocity = Direction;
        gameObject.transform.parent = null;
    }

    
    void Update() {
        Debug.Log(Direction);
        //if (gameObject.transform.parent != null) {
        //    curTime -= Time.deltaTime;
        //}
        //if (gameObject.transform.parent != null && curTime <= 0)
    }
}
