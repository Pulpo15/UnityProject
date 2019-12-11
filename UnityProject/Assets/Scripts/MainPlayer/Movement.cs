using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Rigidbody Player;
    private float speed = 5.0f;
    float mH;
    float mV;

    private void Start() {
        Player = GetComponent<Rigidbody>();
    }

    void Update() {

        Debug.Log(Player.velocity);
        mH = speed * Input.GetAxis("Horizontal");
        mV = speed * Input.GetAxis("Vertical");
        Player.velocity = new Vector3(mH * speed, Player.velocity.y, Player.velocity.z);
        Player.velocity = new Vector3(Player.velocity.x, Player.velocity.y, mV * speed);
    }
}
