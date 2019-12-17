using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarLook : MonoBehaviour
{
    public GameObject Player;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        gameObject.transform.LookAt(Player.transform);
    }
}
