using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public CharacterController Player;
    public float speed = 12f;

    public float gravity = 9.8f;
    public float fallVelocity = 0;

    Vector3 move;

    void Update() {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

         move = transform.right * x + transform.forward * z;

        SetGravity();

        Player.Move(move * speed * Time.deltaTime);
    }

    void SetGravity() {
        if (Player.isGrounded) {
            fallVelocity = -gravity * Time.deltaTime;
            move.y = fallVelocity;
        }
        else {
            fallVelocity -= gravity * Time.deltaTime;
            move.y = fallVelocity;
        }
    }
}
