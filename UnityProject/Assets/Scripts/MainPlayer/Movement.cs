using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private void Start() {
    }

    public CharacterController Player;
    public float speed = 0f;

    public float gravity = 9.8f;
    public float fallVelocity = 0;

    Vector3 move;

    public bool pause = false;


    void Update() {

        if (!pause)
            Time.timeScale = 1;
        else if (pause)
            Time.timeScale = 0;
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pause)
                pause = false;
            else if (!pause)
                pause = true;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //float x = Input.GetAxis("HJoy");
        //float z = Input.GetAxis("VJoy");

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
