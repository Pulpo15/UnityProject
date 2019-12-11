using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public CharacterController Player;
    public float speed = 12f;

    void Update() {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Player.Move(move * speed * Time.deltaTime);

    }
}
