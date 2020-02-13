using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    GameObject Player;
    CharacterController Enemy;

    public float speed = 6f;
    
    private Transform target;
    private int wavePointIndex = 0;
    
    public bool canBeTakenByGun = true;


    void Start() {
        target = Waypoints.points[0];

        Enemy = GetComponent<CharacterController>();
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Player.GetComponent<Collider>() != null)
            Physics.IgnoreCollision(Enemy.GetComponent<Collider>(), Player.GetComponent<Collider>());
    }
    
    void Update() {
        Movement();
    }

    void Movement() {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (wavePointIndex >= Waypoints.points.Length - 1) {
            Destroy(gameObject);
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }
}
